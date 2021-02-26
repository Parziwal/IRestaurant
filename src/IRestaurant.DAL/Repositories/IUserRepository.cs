using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<int?> GetUserRestaurantIdOrNull(string userId);
    }
}
