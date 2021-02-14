using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IRestaurant.BL
{
    public class RestaurantManager
    {
        private IRestaurantRepository restaurantRepository;

        public RestaurantManager(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<IReadOnlyCollection<RestaurantOverview>> ListRestaurantOverviews(string restaurantName = null)
        {
            return await restaurantRepository.ListRestaurantOverviews(restaurantName);
        }

        public async Task<Restaurant> GetRestaurantOrNull(int restaurantId)
        {
            return await restaurantRepository.GetRestaurantOrNull(restaurantId);
        }

        public async Task<Restaurant> CreateDeafaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDeafaultRestaurant(ownerId);
        }
    }
}
