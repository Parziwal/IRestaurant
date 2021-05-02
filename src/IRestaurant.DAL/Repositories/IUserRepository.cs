﻿using IRestaurant.DAL.DTO.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<AddressWithIdDto> GetUserAddress(int addressId);
        Task<IReadOnlyCollection<AddressWithIdDto>> GetUserAddressList(string userId);
        Task<AddressWithIdDto> CreatetUserAddress(string userId, CreateOrEditAddressDto address);
        Task<AddressWithIdDto> EditUserAddress(int addressId, CreateOrEditAddressDto address);
        Task DeleteUserAddress(int addressId);
        Task<string> GetUserAddressUserId(int addressId);
        Task<int> GetUserRestaurantId(string userId);
        Task<bool> UserHasRestaurant(string userId);
        string GetCurrentUserId();
    }
}
