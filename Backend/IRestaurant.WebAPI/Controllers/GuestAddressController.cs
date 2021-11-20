using IRestaurant.BLL.Managers;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.WebAPI.Controllers
{
    /// <summary>
    /// A vendégek saját lakcímeinek lekérdezése és újak létrehozása.
    /// </summary>
    [Authorize(Policy = UserRoles.Guest)]
    [Route("api/[controller]")]
    [ApiController]
    public class GuestAddressController : ControllerBase
    {
        private readonly UserManager userManager;

        public GuestAddressController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// A megadott azonosítójú lakcím lekérdezése.
        /// </summary>
        /// <param name="addressId">A lakcím azonsítója.</param>
        /// <returns>A lakcím adatai.</returns>
        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressWithIdDto>> GetUserAddress(int addressId)
        {
            return await userManager.GetUserAddress(addressId);
        }

        /// <summary>
        /// Az aktuális vendég összes lakcímének lekérdezése.
        /// </summary>
        /// <returns>Az aktuális vendég lakcímeinek listája.</returns>
        [HttpGet]
        public async Task<IEnumerable<AddressWithIdDto>> GetCurrentGuestAddressList()
        {
            return await userManager.GetCurrentGuestAddressList();
        }

        /// <summary>
        /// Lakcím létrehozása az aktuális felhasználóhoz.
        /// </summary>
        /// <param name="address">A létrehozandó lakcím adatai.</param>
        /// <returns>A létrehozott lakcím.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressWithIdDto>> GetUserAddress([FromBody] CreateOrEditAddressDto address)
        {
            var createdAddress = await userManager.CreateUserAddress(address);
            return CreatedAtAction(nameof(GetUserAddress), new { id = createdAddress.Id }, createdAddress);
        }
    }
}
