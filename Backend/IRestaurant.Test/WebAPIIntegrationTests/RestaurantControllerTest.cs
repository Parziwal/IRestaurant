using IdentityModel.Client;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using IRestaurant.Test.Data;
using IRestaurant.Test.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using IRestaurant.DAL.Data;

namespace IRestaurant.Test.WebAPIIntegrationTests
{
    public class RestaurantControllerTest : WebServerFixture
    {

        [Theory]
        [InlineData(RestaurantSortBy.NAME_ASC)]
        [InlineData(RestaurantSortBy.NAME_DESC)]
        [InlineData(RestaurantSortBy.RATING_ASC)]
        [InlineData(RestaurantSortBy.RATING_DESC)]
        [InlineData(RestaurantSortBy.REVIEW_COUNT_ASC)]
        [InlineData(RestaurantSortBy.REVIEW_COUNT_DESC)]
        public async Task GetRestaurantOverviewList_AllAvailable_OnOnePage_SortBy(RestaurantSortBy sortBy)
        {
            //Arrange
            int restaurantsCount = TestSeedService.Restaurants.Count;
            var search = new RestaurantSearchDto
            {
                NameOrShortDescriptionOrCity = "",
                SortBy = sortBy.ToString(),
                PageSize = restaurantsCount,
                PageNumber = 1,
            };
            var orderedRestaurantList = TestSeedService.Restaurants.SortByAll(sortBy);
            var client = webApiServer.CreateClient();

            //Act
            var response = await client.GetAsync("/api/restaurant?" + search.ToQueryParams());
            var restaurantPagedList = await response.Content.ReadFromJsonAsync<PagedListDto<RestaurantOverviewDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(TestSeedService.Restaurants.Count, restaurantPagedList.TotalItemCount);
            Assert.Equal(1, restaurantPagedList.PageCount);
            Assert.True(restaurantPagedList.Result.First().Name == orderedRestaurantList.First().Name);
            Assert.True(restaurantPagedList.Result.Last().Name == orderedRestaurantList.Last().Name);
        }

        [Fact]
        public async Task GetRestaurantDetails_ForAvailableRestaurant()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurant = TestSeedService.Restaurants[restaurantId - 1];
            var ownerFullName = "Peggy Justice";
            var rating = (4.867 + 4.677) / 2.0;
            var client = webApiServer.CreateClient();

            //Act
            var response = await client.GetAsync("/api/restaurant/" + restaurantId);
            var restaurantDetails = await response.Content.ReadFromJsonAsync<RestaurantDetailsDto>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedRestaurant.Name, restaurantDetails.Name);
            Assert.Equal(expectedRestaurant.ShortDescription, restaurantDetails.ShortDescription);
            Assert.Equal(expectedRestaurant.DetailedDescription, restaurantDetails.DetailedDescription);
            Assert.Equal(expectedRestaurant.ImagePath, restaurantDetails.ImagePath);
            Assert.Equal(expectedRestaurant.IsOrderAvailable, restaurantDetails.IsOrderAvailable);
            Assert.Equal(expectedRestaurant.Address.ZipCode, restaurantDetails.RestaurantAddress.ZipCode);
            Assert.Equal(expectedRestaurant.Address.City, restaurantDetails.RestaurantAddress.City);
            Assert.Equal(expectedRestaurant.Address.Street, restaurantDetails.RestaurantAddress.Street);
            Assert.Equal(expectedRestaurant.Address.PhoneNumber, restaurantDetails.RestaurantAddress.PhoneNumber);
            Assert.Equal(ownerFullName, restaurantDetails.OwnerFullName);
            Assert.Equal(rating, restaurantDetails.Rating.Value, 2);
        }

        [Fact]
        public async Task GetRestaurantDetails_ForNonExistingRestaurant()
        {
            //Arrange
            int nonExistingRestaurantId = 10;
            var client = webApiServer.CreateClient();

            //Act
            var response = await client.GetAsync("/api/restaurant/" + nonExistingRestaurantId);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetRestaurantDetails_ForExistingButNotPubliclyAvailableRestaurant()
        {
            //Arrange
            int restaurantId = 1;
            var restaurant = DbContext.Restaurants.SingleOrDefault(r => r.Id == restaurantId);
            restaurant.ShowForUsers = false;
            await DbContext.SaveChangesAsync();
            var client = webApiServer.CreateClient();

            //Act
            var response = await client.GetAsync("/api/restaurant/" + restaurantId);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetMyRestaurantDetails_WhereUserIsRestaurantOwner_RestaurantIsNotPubliclyAvailable()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurant = TestSeedService.Restaurants[restaurantId - 1];
            var ownerFullName = "Peggy Justice";
            var rating = (4.867 + 4.677) / 2.0;

            var restaurant = DbContext.Restaurants.SingleOrDefault(r => r.Id == restaurantId);
            restaurant.ShowForUsers = false;
            await DbContext.SaveChangesAsync();

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.GetAsync("/api/restaurant/myrestaurant");
            var restaurantDetails = await response.Content.ReadFromJsonAsync<RestaurantDetailsDto>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(restaurantId, restaurantDetails.Id);
            Assert.Equal(expectedRestaurant.Name, restaurantDetails.Name);
            Assert.Equal(expectedRestaurant.ShortDescription, restaurantDetails.ShortDescription);
            Assert.Equal(expectedRestaurant.DetailedDescription, restaurantDetails.DetailedDescription);
            Assert.Equal(expectedRestaurant.ImagePath, restaurantDetails.ImagePath);
            Assert.Equal(expectedRestaurant.IsOrderAvailable, restaurantDetails.IsOrderAvailable);
            Assert.Equal(expectedRestaurant.Address.ZipCode, restaurantDetails.RestaurantAddress.ZipCode);
            Assert.Equal(expectedRestaurant.Address.City, restaurantDetails.RestaurantAddress.City);
            Assert.Equal(expectedRestaurant.Address.Street, restaurantDetails.RestaurantAddress.Street);
            Assert.Equal(expectedRestaurant.Address.PhoneNumber, restaurantDetails.RestaurantAddress.PhoneNumber);
            Assert.Equal(ownerFullName, restaurantDetails.OwnerFullName);
            Assert.Equal(rating, restaurantDetails.Rating.Value, 2);
        }

        [Fact]
        public async Task GetMyRestaurantDetails_WhereUserIsGuest()
        {
            //Arrange
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.GetAsync("/api/restaurant/myrestaurant");

            //Assert
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async Task EditMyRestaurantDetails_WhereUserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var editRestaurant = new EditRestaurantDto
            {
                Name = "Teszt Étterem",
                ShortDescription = "Az étterem ismertetője.",
                DetailedDescription = "Az étterem leírása.",
                Address = new CreateOrEditAddressDto
                {
                    ZipCode = 1018,
                    City = "Budapest",
                    Street = "Kossuth utca 11",
                    PhoneNumber = "06-30-192-1234"
                }
            };

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.PutAsJsonAsync("/api/restaurant/myrestaurant", editRestaurant);
            var editedRestaurant = await response.Content.ReadFromJsonAsync<RestaurantDetailsDto>();
            var savedRestaurant = await client.GetAsync("/api/restaurant/" + restaurantId).Result.Content.ReadFromJsonAsync<RestaurantDetailsDto>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(restaurantId, editedRestaurant.Id);
            Assert.Equal(editRestaurant.Name, editedRestaurant.Name);
            Assert.Equal(editRestaurant.ShortDescription, editedRestaurant.ShortDescription);
            Assert.Equal(editRestaurant.DetailedDescription, editedRestaurant.DetailedDescription);
            Assert.Equal(editRestaurant.Address.ZipCode, editedRestaurant.RestaurantAddress.ZipCode);
            Assert.Equal(editRestaurant.Address.City, editedRestaurant.RestaurantAddress.City);
            Assert.Equal(editRestaurant.Address.Street, editedRestaurant.RestaurantAddress.Street);
            Assert.Equal(editRestaurant.Address.PhoneNumber, editedRestaurant.RestaurantAddress.PhoneNumber);

            Assert.Equal(restaurantId, savedRestaurant.Id);
            Assert.Equal(editRestaurant.Name, savedRestaurant.Name);
            Assert.Equal(editRestaurant.ShortDescription, savedRestaurant.ShortDescription);
            Assert.Equal(editRestaurant.DetailedDescription, savedRestaurant.DetailedDescription);
            Assert.Equal(editRestaurant.Address.ZipCode, savedRestaurant.RestaurantAddress.ZipCode);
            Assert.Equal(editRestaurant.Address.City, savedRestaurant.RestaurantAddress.City);
            Assert.Equal(editRestaurant.Address.Street, savedRestaurant.RestaurantAddress.Street);
            Assert.Equal(editRestaurant.Address.PhoneNumber, savedRestaurant.RestaurantAddress.PhoneNumber);
        }

        [Fact]
        public async Task EditMyRestaurantDetails_WhereUserIsGuest()
        {
            //Arrange
            var editRestaurant = new EditRestaurantDto
            {
                Name = "Teszt Étterem",
                ShortDescription = "Az étterem ismertetője.",
                DetailedDescription = "Az étterem leírása.",
                Address = new CreateOrEditAddressDto
                {
                    ZipCode = 1018,
                    City = "Budapest",
                    Street = "Kossuth utca 11",
                    PhoneNumber = "06-30-192-1234"
                }
            };

            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.PutAsJsonAsync("/api/restaurant/myrestaurant", editRestaurant);

            //Assert
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async Task GetMyRestaurantSettings_WhereUserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurant = TestSeedService.Restaurants[restaurantId - 1];

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.GetAsync("/api/restaurant/myrestaurant/settings");
            var restaurantSettings = await response.Content.ReadFromJsonAsync<RestaurantSettingsDto>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedRestaurant.IsOrderAvailable, restaurantSettings.IsOrderAvailable);
            Assert.Equal(expectedRestaurant.ShowForUsers, restaurantSettings.ShowForUsers);
        }

        [Fact]
        public async Task GetMyRestaurantSettings_WhereUserIsGuest()
        {
            //Arrange
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.GetAsync("/api/restaurant/myrestaurant/settings");

            //Assert
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async Task ShowMyRestaurantForUsers_WhereRestaurantWasNotAvailable_And_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;

            var restaurant = DbContext.Restaurants.SingleOrDefault(r => r.Id == restaurantId);
            restaurant.ShowForUsers = false;
            await DbContext.SaveChangesAsync();

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();

            //Act
            var originalRestaurantResponse = await client.GetAsync("/api/restaurant/" + restaurantId);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var statusChangeResponse = await client.PatchAsync("/api/restaurant/myrestaurant/show", null);

            var actualRestaurantSettings = await client.GetAsync("/api/restaurant/myrestaurant/settings").Result.Content.ReadFromJsonAsync<RestaurantSettingsDto>();

            client.DefaultRequestHeaders.Clear();
            var actualRestaurantResponse = await client.GetAsync("/api/restaurant/" + restaurantId);
            var actualRestaurantDetails = await actualRestaurantResponse.Content.ReadFromJsonAsync<RestaurantDetailsDto>();

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, originalRestaurantResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, statusChangeResponse.StatusCode);
            Assert.True(actualRestaurantSettings.ShowForUsers);
            Assert.Equal(HttpStatusCode.OK, actualRestaurantResponse.StatusCode);
            Assert.Equal(restaurantId, actualRestaurantDetails.Id);
        }

        [Fact]
        public async Task HideMyRestaurantForUsers_WhereRestaurantWasAvailable_And_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();

            //Act
            var originalRestaurantResponse = await client.GetAsync("/api/restaurant/" + restaurantId);
            var originalRestaurantDetails = await originalRestaurantResponse.Content.ReadFromJsonAsync<RestaurantDetailsDto>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var statusChangeResponse = await client.PatchAsync("/api/restaurant/myrestaurant/hide", null);

            var actualRestaurantSettings = await client.GetAsync("/api/restaurant/myrestaurant/settings").Result.Content.ReadFromJsonAsync<RestaurantSettingsDto>();

            client.DefaultRequestHeaders.Clear();
            var actualRestaurantResponse = await client.GetAsync("/api/restaurant/" + restaurantId);
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, originalRestaurantResponse.StatusCode);
            Assert.Equal(restaurantId, originalRestaurantDetails.Id);
            Assert.Equal(HttpStatusCode.OK, statusChangeResponse.StatusCode);
            Assert.False(actualRestaurantSettings.ShowForUsers);
            Assert.Equal(HttpStatusCode.BadRequest, actualRestaurantResponse.StatusCode);
        }

        [Fact]
        public async Task TurnOnMyRestaurantOrderOption_WhereRestaurantWasAvailableButOrderOptionWasTurnedOffAndRestaurantHadFoods_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;

            var restaurant = DbContext.Restaurants.SingleOrDefault(r => r.Id == restaurantId);
            restaurant.IsOrderAvailable = false;
            await DbContext.Foods.AddAsync(new Food()
            {
                Name = "Teszt Étel",
                Price = 1000,
                Description = "Teszt Étel leírása",
                RestaurantId = restaurantId
            });
            await DbContext.SaveChangesAsync();

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var originalRestaurantSettings = await client.GetAsync("/api/restaurant/myrestaurant/settings").Result.Content.ReadFromJsonAsync<RestaurantSettingsDto>();
            
            var statusChangeResponse = await client.PatchAsync("/api/restaurant/myrestaurant/order/turnon", null);

            var actualRestaurantSettings = await client.GetAsync("/api/restaurant/myrestaurant/settings").Result.Content.ReadFromJsonAsync<RestaurantSettingsDto>();

            //Assert
            Assert.True(originalRestaurantSettings.ShowForUsers);
            Assert.False(originalRestaurantSettings.IsOrderAvailable);
            Assert.Equal(HttpStatusCode.OK, statusChangeResponse.StatusCode);
            Assert.True(actualRestaurantSettings.IsOrderAvailable);
        }

        [Fact]
        public async Task TurnOnMyRestaurantOrderOption_WhereRestaurantWasNotAvailableAndRestaurantHadFoods_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;

            var restaurant = DbContext.Restaurants.SingleOrDefault(r => r.Id == restaurantId);
            restaurant.ShowForUsers = false;
            await DbContext.Foods.AddAsync(new Food()
            {
                Name = "Teszt Étel",
                Price = 1000,
                Description = "Teszt Étel leírása",
                RestaurantId = restaurantId
            });
            await DbContext.SaveChangesAsync();

            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var statusChangeResponse = await client.PatchAsync("/api/restaurant/myrestaurant/order/turnon", null);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, statusChangeResponse.StatusCode);
        }

        [Fact]
        public async Task TurnOnMyRestaurantOrderOption_WhereRestaurantWasAvailableButRestaurantDidntHaveFoods_UserIsRestaurantOwner()
        {
            //Arrange
            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var statusChangeResponse = await client.PatchAsync("/api/restaurant/myrestaurant/order/turnon", null);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, statusChangeResponse.StatusCode);
        }

        [Fact]
        public async Task TurnOffMyRestaurantOrderOption_WhereRestaurantOrderOptionWasTurnedOn_UserIsRestaurantOwner()
        {
            //Arrange
            var accessToken = await authServer.GetAccessToken("peggy@email.hu", "Test.54321"); //Az 1-es azonosítójú étterem tulajdonosa
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var originalRestaurantSettings = await client.GetAsync("/api/restaurant/myrestaurant/settings").Result.Content.ReadFromJsonAsync<RestaurantSettingsDto>();

            var statusChangeResponse = await client.PatchAsync("/api/restaurant/myrestaurant/order/turnoff", null);

            var actualRestaurantSettings = await client.GetAsync("/api/restaurant/myrestaurant/settings").Result.Content.ReadFromJsonAsync<RestaurantSettingsDto>();

            //Assert
            Assert.True(originalRestaurantSettings.IsOrderAvailable);
            Assert.Equal(HttpStatusCode.OK, statusChangeResponse.StatusCode);
            Assert.False(actualRestaurantSettings.IsOrderAvailable);
        }

        [Theory]
        [InlineData(RestaurantSortBy.NAME_ASC)]
        [InlineData(RestaurantSortBy.NAME_DESC)]
        [InlineData(RestaurantSortBy.RATING_ASC)]
        [InlineData(RestaurantSortBy.RATING_DESC)]
        [InlineData(RestaurantSortBy.REVIEW_COUNT_ASC)]
        [InlineData(RestaurantSortBy.REVIEW_COUNT_DESC)]
        public async Task GetGuestFavouriteRestaurantList_CarsonFavourites_OnOnePage_SortBy(RestaurantSortBy sortBy)
        {
            //Arrange
            int restaurantsCount = TestSeedService.Restaurants.Count;
            var search = new RestaurantSearchDto
            {
                NameOrShortDescriptionOrCity = "",
                SortBy = sortBy.ToString(),
                PageSize = restaurantsCount,
                PageNumber = 1,
            };
            var orderedRestaurantList = TestSeedService.Restaurants.SortByCarsonFavourite(sortBy);
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var response = await client.GetAsync("/api/restaurant/favourite?" + search.ToQueryParams());
            var restaurantPagedList = await response.Content.ReadFromJsonAsync<PagedListDto<RestaurantOverviewDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, restaurantPagedList.TotalItemCount);
            Assert.Equal(1, restaurantPagedList.PageCount);
            Assert.True(restaurantPagedList.Result.First().Name == orderedRestaurantList.First().Name);
            Assert.True(restaurantPagedList.Result.Last().Name == orderedRestaurantList.Last().Name);
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_WhereRestaurantExistsAndNotAdded()
        {
            //Arrange
            int restaurantId = 3;
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var addRestaurantResponse = await client.PostAsync("/api/restaurant/favourite/add/" + restaurantId, null);

            var favouriteRestaurants = await client.GetAsync("/api/restaurant/favourite").Result.Content.ReadFromJsonAsync<PagedListDto<RestaurantOverviewDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, addRestaurantResponse.StatusCode);
            Assert.Equal(3, favouriteRestaurants.Result.Count());
            Assert.Contains(favouriteRestaurants.Result, fr => fr.Id == restaurantId);
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_WhereRestaurantNotExists()
        {
            //Arrange
            int nonExistingRestaurantId = 10;
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var addRestaurantResponse = await client.PostAsync("/api/restaurant/favourite/add/" + nonExistingRestaurantId, null);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, addRestaurantResponse.StatusCode);
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_WhereRestaurantExistsButAlreadyAdded()
        {
            //Arrange
            int restaurantId = 1;
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var addRestaurantResponse = await client.PostAsync("/api/restaurant/favourite/add/" + restaurantId, null);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, addRestaurantResponse.StatusCode);
        }

        [Fact]
        public async Task RemoveRestaurantFromGuestFavourite_WhereRestaurantExists()
        {
            //Arrange
            int restaurantId = 1;
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var removeRestaurantResponse = await client.DeleteAsync("/api/restaurant/favourite/remove/" + restaurantId);

            var favouriteRestaurants = await client.GetAsync("/api/restaurant/favourite").Result.Content.ReadFromJsonAsync<PagedListDto<RestaurantOverviewDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, removeRestaurantResponse.StatusCode);
            Assert.Single(favouriteRestaurants.Result);
            Assert.DoesNotContain(favouriteRestaurants.Result, fr => fr.Id == restaurantId);
        }

        [Fact]
        public async Task RemoveRestaurantFromGuestFavourite_WhereRestaurantNotExists()
        {
            //Arrange
            int nonExistingRestaurantId = 10;
            var accessToken = await authServer.GetAccessToken("carson@email.hu", "Test.54321"); //Vendég felhasználó
            var client = webApiServer.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //Act
            var removeRestaurantResponse = await client.DeleteAsync("/api/restaurant/favourite/remove/" + nonExistingRestaurantId);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, removeRestaurantResponse.StatusCode);
        }
    }
}
