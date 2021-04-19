using IRestaurant.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<AddressWithIdDto> GetUserAddress(int addressId);
        Task<IReadOnlyCollection<AddressWithIdDto>> GetUserAddressList(string userId);
        Task<AddressWithIdDto> CreatetUserAddress(string userId, CreateOrEditAddressDto address);
        Task<string> GetUserAddressUserId(int addressId);
        Task<int> GetUserRestaurantId(string userId);
        Task<bool> UserHasRestaurant(string userId);
        string GetCurrentUserId();
    }
}
