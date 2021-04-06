using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<int> GetUserRestaurantId(string userId);
        Task<bool> UserHasRestaurant(string userId);
        string GetCurrentUserId();
    }
}
