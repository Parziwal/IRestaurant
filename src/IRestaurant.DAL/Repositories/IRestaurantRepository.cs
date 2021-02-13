using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRestaurant.DAL;

namespace IRestaurant.DAL.Repository
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyCollection<DTO.RestaurantOverview>> ListRestaurantOverviews();
        Task<IReadOnlyCollection<DTO.Restaurant>> GetRestaurantOrNull(int restaurantId);
        Task InsertDeafaultRestaurant(int ownerId);
        Task EditRestaurant(DTO.EditRestaurant editRestaurant);
        Task ShowRestaurantForUsers();
        Task HideRestaurantFromUsers();
        Task TurnOnOrderOption();
        Task TurnOffOrderOption();
    }
}
