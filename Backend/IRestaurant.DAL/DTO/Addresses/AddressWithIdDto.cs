using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// A felhasználók címei ezen formátumban kerülnek visszaküldésre a kliensnek, az azonosítókat is tartalmazva.
    /// </summary>
    public class AddressWithIdDto : AddressDto
    {
        /// <summary>
        /// A cím egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        AddressWithIdDto() { }

        /// <summary>
        /// A konstruktorban átadott felhasználói cím alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="userAddress">A felhasználó címável kapcsolatos adatokat tartalmazó osztály.</param>
        public AddressWithIdDto(UserAddress userAddress) : base(userAddress.Address)
        {
            this.Id = userAddress.Id;
        }
    }
}
