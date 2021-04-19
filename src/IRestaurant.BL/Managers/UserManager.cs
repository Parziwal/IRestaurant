using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;

namespace IRestaurant.BL.Managers
{
    public class UserManager
    {
        private readonly IUserRepository userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<AddressWithIdDto> GetUserAddress(int addressId)
        {
            string userId = userRepository.GetCurrentUserId();
            string addressUserId = await userRepository.GetUserAddressUserId(addressId);

            if (userId == addressUserId)
            {
                return await userRepository.GetUserAddress(addressId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
               "A megadott azonosítóval rendelkező lakcím megtekintéséhez nincs jogosultságod.");
        }

        public async Task<IReadOnlyCollection<AddressWithIdDto>> GetCurrentGuestAddressList()
        {
            string userId = userRepository.GetCurrentUserId();
            return await userRepository.GetUserAddressList(userId);
        }

        public async Task<AddressWithIdDto> CreateUserAddresses(CreateOrEditAddressDto address)
        {
            string userId = userRepository.GetCurrentUserId();
            return await userRepository.CreatetUserAddress(userId, address);
        }
    }
}
