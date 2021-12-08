using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.Repositories.Implementations;
using IRestaurant.Test.Data;
using IRestaurant.Test.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IRestaurant.Test.RepositoryUnitTests
{
    public class RestaurantRepositoryTest : SqliteInMemoryDbInit
    {
        RestaurantRepositoryTestHelper helper = new RestaurantRepositoryTestHelper();

        [Theory]
        [InlineData(RestaurantSortBy.NAME_ASC)]
        [InlineData(RestaurantSortBy.NAME_DESC)]
        [InlineData(RestaurantSortBy.RATING_ASC)]
        [InlineData(RestaurantSortBy.RATING_DESC)]
        [InlineData(RestaurantSortBy.REVIEW_COUNT_ASC)]
        [InlineData(RestaurantSortBy.REVIEW_COUNT_DESC)]
        public async Task GetRestaurantOverviewList_AllAvailable_OnOnePage_SortBy(RestaurantSortBy sortBy)
        {
            using (var dbContext = CreateDbContext())
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
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedList = await repository.GetRestaurantOverviewList(search);

                //Assert
                Assert.Equal(restaurantsCount, restaurantPagedList.TotalItemCount);
                Assert.Equal(1, restaurantPagedList.PageCount);
                Assert.True(restaurantPagedList.Result.First().Name == orderedRestaurantList.First().Name);
                Assert.True(restaurantPagedList.Result.Last().Name == orderedRestaurantList.Last().Name);
            }
        }

        [Fact]
        public async Task GetRestaurantOverviewList_OnlyThatContainsBudapest_OnOnePage()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "Budapest",
                    PageSize = TestSeedService.Restaurants.Count,
                    PageNumber = 1,
                };
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedList = await repository.GetRestaurantOverviewList(search);

                //Assert
                var restaurants = restaurantPagedList.Result.ToList();

                Assert.Equal(2, restaurantPagedList.TotalItemCount);
                Assert.Equal(1, restaurantPagedList.PageCount);
                Assert.Equal(TestSeedService.Restaurants[0].Name, restaurants[0].Name);
                Assert.Equal(TestSeedService.Restaurants[1].Name, restaurants[1].Name);
            }
        }

        [Fact]
        public async Task GetRestaurantOverviewList_TwoPerPage()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "",
                    PageSize = 2,
                    PageNumber = 1,
                };
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedListOne = await repository.GetRestaurantOverviewList(search);
                search.PageNumber = 2;
                var restaurantPagedListTwo = await repository.GetRestaurantOverviewList(search);

                //Assert
                Assert.Equal(2, restaurantPagedListOne.PageCount);
                Assert.Equal(2, restaurantPagedListOne.Result.Count());
                Assert.Single(restaurantPagedListTwo.Result);
            }
        }

        [Fact]
        public async Task GetRestaurantOverviewList_WithNoResult()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "Ez nem létezik.",
                    PageSize = TestSeedService.Restaurants.Count,
                    PageNumber = 1,
                };
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedList = await repository.GetRestaurantOverviewList(search);

                //Assert
                Assert.Equal(0, restaurantPagedList.TotalItemCount);
            }
        }

        [Fact]
        public async Task GetRestaurantDetails_ForExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int restuarantId = 1;
                var expectedRestaurant = TestSeedService.Restaurants[restuarantId - 1];
                var ownerFullName = "Peggy Justice";
                var rating = (4.867 + 4.677) / 2.0;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantDetails = await repository.GetRestaurantDetails(restuarantId);

                //Assert
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
        }

        [Fact]
        public async Task GetRestaurantDetails_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.GetRestaurantDetails(nonExistingRestaurantId)
                );
            }
        }

        [Fact]
        public async Task EditRestaurant_WhichExists()
        {
            //Arrange
            const int editRestaurantId = 1;
            var editRestaurant = new EditRestaurantDto
            {
                Name = "Teszt Étterem",
                ShortDescription = "Az étterem ismertetõje.",
                DetailedDescription = "Az étterem leírása.",
                Address = new CreateOrEditAddressDto
                {
                    ZipCode = 1018,
                    City = "Budapest",
                    Street = "Kossuth utca 11",
                    PhoneNumber = "06301921234"
                }
            };

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var editedRestaurant = await repository.EditRestaurant(editRestaurantId, editRestaurant);

                //Assert
                Assert.Equal(editRestaurant.Name, editedRestaurant.Name);
                Assert.Equal(editRestaurant.ShortDescription, editedRestaurant.ShortDescription);
                Assert.Equal(editRestaurant.DetailedDescription, editedRestaurant.DetailedDescription);
                Assert.Equal(editRestaurant.Address.ZipCode, editedRestaurant.RestaurantAddress.ZipCode);
                Assert.Equal(editRestaurant.Address.City, editedRestaurant.RestaurantAddress.City);
                Assert.Equal(editRestaurant.Address.Street, editedRestaurant.RestaurantAddress.Street);
                Assert.Equal(editRestaurant.Address.PhoneNumber, editedRestaurant.RestaurantAddress.PhoneNumber);
            }

            using (var dbContext = CreateDbContext())
            {
                var savedRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == editRestaurantId);

                Assert.Equal(editRestaurant.Name, savedRestaurant.Name);
                Assert.Equal(editRestaurant.ShortDescription, savedRestaurant.ShortDescription);
                Assert.Equal(editRestaurant.DetailedDescription, savedRestaurant.DetailedDescription);
                Assert.Equal(editRestaurant.Address.ZipCode, savedRestaurant.Address.ZipCode);
                Assert.Equal(editRestaurant.Address.City, savedRestaurant.Address.City);
                Assert.Equal(editRestaurant.Address.Street, savedRestaurant.Address.Street);
                Assert.Equal(editRestaurant.Address.PhoneNumber, savedRestaurant.Address.PhoneNumber);
            }
        }

        [Fact]
        public async Task EditRestaurant_WhichNotExists()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.EditRestaurant(nonExistingRestaurantId, new EditRestaurantDto())
                );
            }
        }

        [Fact]
        public async Task UploadRestaurantImage_ForExistingRestaurant()
        {
            //Arrange
            int restaurantId = 1;
            string imageName = "uj_kep_az_etteremhez";

            using (var dbContext = CreateDbContext())
            {
                var formFile = new Mock<IFormFile>();
                formFile.SetupGet(f => f.FileName).Returns(imageName);
                var imageRepository = new Mock<IImageRepository>();
                imageRepository.Setup(i => i.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()))
                    .ReturnsAsync((IFormFile iff, string _) => iff.FileName);
                imageRepository.Setup(i => i.DeleteImage("/images/restaurant/trofea.jpg"))
                    .Verifiable();
                var restaurantRepository = helper.CreateRestaurantRepository(dbContext, imageRepository.Object);

                //Act
                var returnedImagePath = await restaurantRepository.UploadRestaurantImage(restaurantId, new UploadImageDto { ImageFile = formFile.Object });

                //Assert
                Assert.Contains(imageName, returnedImagePath);
                imageRepository.Verify();
            }

            using (var dbContext = CreateDbContext())
            {
                var savedRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);
                Assert.Contains(imageName, savedRestaurant.ImagePath);
            }
        }

        [Fact]
        public async Task UploadRestaurantImage_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var restaurantRepository = helper.CreateRestaurantRepository(dbContext);

                //Act
                 
                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await restaurantRepository.UploadRestaurantImage(nonExistingRestaurantId, new UploadImageDto())
                );
            }
        }

        [Fact]
        public async Task DeleteRestaurantImage_ForExistingRestaurant()
        {
            //Arrange
            int restaurantId = 1;

            using (var dbContext = CreateDbContext())
            {
                var imageRepository = new Mock<IImageRepository>();
                imageRepository.Setup(i => i.DeleteImage("/images/restaurant/trofea.jpg"))
                    .Verifiable();
                var restaurantRepository = helper.CreateRestaurantRepository(dbContext, imageRepository.Object);

                //Act
                await restaurantRepository.DeleteRestaurantImage(restaurantId);
                imageRepository.Verify();
            }

            using (var dbContext = CreateDbContext())
            {
                //Assert
                var savedRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);
                Assert.Null(savedRestaurant.ImagePath);
            }
        }

        [Fact]
        public async Task DeleteRestaurantImage_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var restaurantRepository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await restaurantRepository.DeleteRestaurantImage(nonExistingRestaurantId)
                );
            }
        }

        [Fact]
        public async Task GetRestaurantSettings_ForExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int restaurantId = 1;
                var expectedRestaurant = TestSeedService.Restaurants[restaurantId - 1];
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantSettings = await repository.GetRestaurantSettings(restaurantId);

                //Assert
                Assert.Equal(expectedRestaurant.ShowForUsers, restaurantSettings.ShowForUsers);
                Assert.Equal(expectedRestaurant.IsOrderAvailable, restaurantSettings.IsOrderAvailable);
            }
        }

        [Fact]
        public async Task GetRestaurantSettings_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.GetRestaurantSettings(nonExistingRestaurantId)
                );
            }
        }

        [Fact]
        public async Task ChangeShowForUsersStatus_ForExistingRestaurant()
        {
            //Arrange
            const int editRestaurantId = 1;
            const bool showForUsersStatus = false;

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                await repository.ChangeShowForUsersStatus(editRestaurantId, showForUsersStatus);
            }

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);
                var savedRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == editRestaurantId);

                //Assert
                Assert.Equal(showForUsersStatus, savedRestaurant.ShowForUsers);
            }
        }

        [Fact]
        public async Task ChangeShowForUsersStatus_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.ChangeShowForUsersStatus(nonExistingRestaurantId, false)
                );
            }
        }

        [Fact]
        public async Task ChangeOrderAvailableStatus_ForExistingRestaurant()
        {
            //Arrange
            const int editRestaurantId = 1;
            const bool orderAvailableStatus = false;

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                await repository.ChangeOrderAvailableStatus(editRestaurantId, orderAvailableStatus);
            }

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);
                var savedRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == editRestaurantId);

                //Assert
                Assert.Equal(orderAvailableStatus, savedRestaurant.IsOrderAvailable);
            }
        }

        [Fact]
        public async Task ChangeOrderAvailableStatus_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.ChangeOrderAvailableStatus(nonExistingRestaurantId, false)
                );
            }
        }

        [Fact]
        public async Task IsRestaurantAvailableForUsers_ForExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                const int restaurantId = 1;
                var expectedRestaurantAvailableStatus = TestSeedService.Restaurants[restaurantId - 1].IsOrderAvailable;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantAvailableStatus = await repository.IsRestaurantAvailableForUsers(restaurantId);

                //Assert
                Assert.Equal(expectedRestaurantAvailableStatus, restaurantAvailableStatus);
            }
        }

        [Fact]
        public async Task IsRestaurantAvailableForUsers_ForNonExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.IsRestaurantAvailableForUsers(nonExistingRestaurantId)
                );
            }
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
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                string carsonUserId = TestSeedService.Users[0].Id;
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "",
                    SortBy = sortBy.ToString(),
                    PageSize = TestSeedService.Restaurants.Count,
                    PageNumber = 1,
                };
                var orderedRestaurantList = TestSeedService.Restaurants.SortByCarsonFavourite(sortBy);
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedList = await repository.GetGuestFavouriteRestaurantList(carsonUserId, search);

                //Assert
                Assert.Equal(2, restaurantPagedList.TotalItemCount);
                Assert.Equal(1, restaurantPagedList.PageCount);
                Assert.True(restaurantPagedList.Result.First().Name == orderedRestaurantList.First().Name);
                Assert.True(restaurantPagedList.Result.Last().Name == orderedRestaurantList.Last().Name);
            }
        }

        [Fact]
        public async Task GetGuestFavouriteRestaurantList_CarsonFavourites_OnlyThatContainsGrill_OnOnePage()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                string carsonUserId = TestSeedService.Users[0].Id;
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "Grill",
                    PageSize = TestSeedService.Restaurants.Count,
                    PageNumber = 1,
                };
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedList = await repository.GetGuestFavouriteRestaurantList(carsonUserId, search);

                //Assert
                Assert.Equal(1, restaurantPagedList.TotalItemCount);
                Assert.Equal(1, restaurantPagedList.PageCount);
            }
        }

        [Fact]
        public async Task GetGuestFavouriteRestaurantList_CarsonFavourites_OnePerPage()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                string carsonUserId = TestSeedService.Users[0].Id;
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "",
                    PageSize = 1,
                    PageNumber = 1,
                };
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedListOne = await repository.GetGuestFavouriteRestaurantList(carsonUserId, search);
                search.PageNumber = 2;
                var restaurantPagedListTwo = await repository.GetGuestFavouriteRestaurantList(carsonUserId, search);

                //Assert
                Assert.Equal(2, restaurantPagedListOne.PageCount);
                Assert.Single(restaurantPagedListOne.Result);
                Assert.Single(restaurantPagedListTwo.Result);
            }
        }

        [Fact]
        public async Task GetGuestFavouriteRestaurantList_ForNonExistingUser()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                string nonExistingUserId = "70ceb6e6-9a79-4fb8-b325-93453e2021b1";
                var search = new RestaurantSearchDto
                {
                    NameOrShortDescriptionOrCity = "",
                    PageSize = TestSeedService.Restaurants.Count,
                    PageNumber = 1,
                };
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                var restaurantPagedList = await repository.GetGuestFavouriteRestaurantList(nonExistingUserId, search);

                //Assert
                Assert.Equal(0, restaurantPagedList.TotalItemCount);
            }
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_NotAddedAndExistingRestaurant()
        {
            //Arrange
            int favouriteRestaurantId = 3;
            string carsonUserId = TestSeedService.Users[0].Id;

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                await repository.AddRestaurantToGuestFavourite(favouriteRestaurantId, carsonUserId);
            }

            using (var dbContext = CreateDbContext())
            {
                //Assert
                Assert.True(await dbContext.FavouriteRestaurants
                    .AnyAsync(fr => fr.RestaurantId == favouriteRestaurantId && fr.UserId == carsonUserId));
            }
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_AlreadyAddedAndExistingRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int alreadyAddedRestaurantId = 1;
                string carsonUserId = TestSeedService.Users[0].Id;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityAlreadyExistsException>(
                    async () => await repository.AddRestaurantToGuestFavourite(alreadyAddedRestaurantId, carsonUserId)
                );
            }
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_ForNonExistingRestaurantAndExistingUser()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                string carsonUserId = TestSeedService.Users[0].Id;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.AddRestaurantToGuestFavourite(nonExistingRestaurantId, carsonUserId)
                );
            }
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite_ForExistingRestaurantAndNonExistingUser()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int favouriteRestaurantId = 3;
                string nonExistingUserId = "70ceb6e6-9a79-4fb8-b325-93453e2021b1";
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.AddRestaurantToGuestFavourite(favouriteRestaurantId, nonExistingUserId)
                );
            }
        }

        [Fact]
        public async Task RemoveRestaurantFromGuestFavourite_ForExistingRestaurantAndUser()
        {
            //Arrange
            int favouriteRestaurantId = 1;
            string carsonUserId = TestSeedService.Users[0].Id;

            using (var dbContext = CreateDbContext())
            {
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act
                await repository.RemoveRestaurantFromGuestFavourite(favouriteRestaurantId, carsonUserId);
            }

            using (var dbContext = CreateDbContext())
            {
                //Assert
                Assert.False(await dbContext.FavouriteRestaurants
                    .AnyAsync(fr => fr.RestaurantId == favouriteRestaurantId && fr.UserId == carsonUserId));
            }
        }

        [Fact]
        public async Task RemoveRestaurantFromGuestFavourite_ForNonExistingRestaurantAndExistingUser()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int nonExistingRestaurantId = 10;
                string carsonUserId = TestSeedService.Users[0].Id;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.RemoveRestaurantFromGuestFavourite(nonExistingRestaurantId, carsonUserId)
                );
            }
        }

        [Fact]
        public async Task RemoveRestaurantFromGuestFavourite_ForExistingRestaurantAndNonExistingUser()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int favouriteRestaurantId = 1;
                string nonExistingUserId = "70ceb6e6-9a79-4fb8-b325-93453e2021b1";
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                await Assert.ThrowsAsync<EntityNotFoundException>(
                    async () => await repository.RemoveRestaurantFromGuestFavourite(favouriteRestaurantId, nonExistingUserId)
                );
            }
        }

        [Fact]
        public async Task IsThisRestaurantGuestFavourite_ForExistingGuestFavouriteRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int favouriteRestaurantId = 1;
                string carsonUserId = TestSeedService.Users[0].Id;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                Assert.True(await repository.IsThisRestaurantGuestFavourite(favouriteRestaurantId, carsonUserId));
            }
        }

        [Fact]
        public async Task IsThisRestaurantGuestFavourite_ForExistingNonGuestFavouriteRestaurant()
        {
            using (var dbContext = CreateDbContext())
            {
                //Arrange
                int favouriteRestaurantId = 3;
                string carsonUserId = TestSeedService.Users[0].Id;
                var repository = helper.CreateRestaurantRepository(dbContext);

                //Act

                //Assert
                Assert.False(await repository.IsThisRestaurantGuestFavourite(favouriteRestaurantId, carsonUserId));
            }
        }
    }
}
