using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// A felhasználók és éttermek címei ezen formátumban kerülnek visszaküldésre a kliensnek.
    /// </summary>
    public class AddressDto
    {
        /// <summary>
        /// Az irányítószám.
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// A város.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Az utca és házszám.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// A címhez tartozó telefonos elérehtőség.
        /// </summary>
        public string PhoneNumber { get; set; }

        public AddressDto() { }

        /// <summary>
        /// A konstruktorban átadott cím osztály alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="address">Címel kapcsolatos adatokat tartalmazó osztály.</param>
        public AddressDto(AddressOwned address)
        {
            this.ZipCode = address.ZipCode;
            this.City = address.City;
            this.Street = address.Street;
            this.PhoneNumber = address.PhoneNumber;
        }
    }
}
