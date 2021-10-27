using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using IRestaurant.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace IRestaurant.Test.ManagerUnitTests
{
    public class RestaurantManagerTestHelper
    {
        public PagedListDto<RestaurantOverviewDto> GetRestaurantOverviewPagedList()
        {
            var restaurant = TestSeedService.Restaurants[0];
            restaurant.Owner = TestSeedService.Users[2];
            restaurant.Reviews = new List<Review>();
            var pagedList = new PagedList<RestaurantOverviewDto>(
                    new List<RestaurantOverviewDto>() {
                        new RestaurantOverviewDto(restaurant)
                    },
                    1,
                    1
                );

            return new PagedListDto<RestaurantOverviewDto>(pagedList);
        }

        public ClaimsPrincipal GetUserClaimPrinciple(string userId)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, userId) }));
        }

        public RestaurantDetailsDto GetRestaurantDetailsDto()
        {
            var restaurant = TestSeedService.Restaurants[0];
            restaurant.Owner = TestSeedService.Users[2];
            restaurant.Reviews = new List<Review>();

            return new RestaurantDetailsDto(restaurant);
        }

        public RestaurantSettingsDto GetRestaurantSettings()
        {
            return new RestaurantSettingsDto(TestSeedService.Restaurants[0]);
        }

        public IReadOnlyCollection<FoodDto> GetRestaurantMenuWithOneFood()
        {
            var food = new Food()
            {
                Name = "Teszt Étel",
                Price = 2000,
                Description = "Teszt Leírás",
                Restaurant = TestSeedService.Restaurants[0]
            };
            return new List<FoodDto>()
            {
                new FoodDto(food)
            };
        }
    }
}
