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
    /// <summary>
    /// A vendégek saját lakcímeinek lekérdezése és újak létrehozása.
    /// </summary>
    [Authorize(Policy = UserRoles.Guest)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly UserAddressManager userAddressManager;

        /// <summary>
        /// A szükséges üzleti logikai függőségek elkérése.
        /// </summary>
        /// <param name="userAddressManager">A vendég lakcímeit kezeli.</param>
        public UserAddressController(UserAddressManager userAddressManager)
        {
            this.userAddressManager = userAddressManager;
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
            return await userAddressManager.GetUserAddress(addressId);
        }

        /// <summary>
        /// Az aktuális vendég összes lakcímének lekérdezése.
        /// </summary>
        /// <returns>Az aktuális vendég lakcímeinek listája.</returns>
        [HttpGet]
        public async Task<IEnumerable<AddressWithIdDto>> GetCurrentGuestAddressList()
        {
            return await userAddressManager.GetCurrentGuestAddressList();
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
            var createdAddress = await userAddressManager.CreateUserAddress(address);
            return CreatedAtAction(nameof(GetUserAddress), new { id = createdAddress.Id }, createdAddress);
        }
    }
}
