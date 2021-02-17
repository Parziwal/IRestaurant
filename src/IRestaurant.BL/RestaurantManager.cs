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

        public async Task<Restaurant> EditRestaurant(int restaurantId, EditRestaurant editRestaurant)
        {
            return await restaurantRepository.EditRestaurant(restaurantId, editRestaurant);
        }
        public async Task<Restaurant> ShowRestaurantForUsers(int restaurantId)
        {
            if (!(await restaurantRepository.IsAllRestaurantDataGiven(restaurantId)))
            {
                throw new ArgumentException("A kötelező adatok megadása nélkül az étterem nem publikálható.");
            }
            return await restaurantRepository.ShowRestaurantForUsers(restaurantId);
        }
        public async Task<Restaurant> HideRestaurantFromUsers(int restaurantId)
        {
            return await restaurantRepository.HideRestaurantFromUsers(restaurantId);
        }
        public async Task<Restaurant> TurnOnOrderOption(int restaurantId)
        {
            if (!(await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId)))
            {
                throw new ArgumentException("A rendelési lehetőség nem engedélyezhető, amíg az étterem láthatósága privát.");
            }
            return await restaurantRepository.TurnOnOrderOption(restaurantId);
        }
        public async Task<Restaurant> TurnOffOrderOption(int restaurantId)
        {
            return await restaurantRepository.TurnOffOrderOption(restaurantId);
        }
    }
}
