using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager userManager;
        public UsersController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressWithIdDto>> GetUserAddress(int addressId)
        {
            return await userManager.GetUserAddress(addressId);
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("address")]
        public async Task<IEnumerable<AddressWithIdDto>> GetCurrentGuestAddresses()
        {
            return await userManager.GetCurrentGuestAddressList();
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpPost("address")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressWithIdDto>> GetUserAddress([FromBody] CreateOrEditAddressDto address)
        {
            var createdAddress = await userManager.CreateUserAddresses(address);
            return CreatedAtAction(nameof(GetUserAddress), new { id = createdAddress.Id }, createdAddress);
        }
    }
}
