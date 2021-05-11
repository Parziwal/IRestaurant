using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly UserAddressManager userAddressManager;
        public UserAddressController(UserAddressManager userAddressManager)
        {
            this.userAddressManager = userAddressManager;
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressWithIdDto>> GetUserAddress(int addressId)
        {
            return await userAddressManager.GetUserAddress(addressId);
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet]
        public async Task<IEnumerable<AddressWithIdDto>> GetCurrentGuestAddressList()
        {
            return await userAddressManager.GetCurrentGuestAddressList();
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressWithIdDto>> GetUserAddress([FromBody] CreateOrEditAddressDto address)
        {
            var createdAddress = await userAddressManager.CreateUserAddress(address);
            return CreatedAtAction(nameof(GetUserAddress), new { id = createdAddress.Id }, createdAddress);
        }
    }
}
