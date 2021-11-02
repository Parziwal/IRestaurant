using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// A lakcím infromációkat tartalmazó adatáviteli objektum.
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

        public AddressDto(AddressOwned address)
        {
            this.ZipCode = address.ZipCode;
            this.City = address.City;
            this.Street = address.Street;
            this.PhoneNumber = address.PhoneNumber;
        }
    }
}
