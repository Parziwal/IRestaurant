using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Addresses
{
    public class AddressDto
    {
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }

        public AddressDto(AddressOwned address)
        {
            this.ZipCode = address.ZipCode;
            this.City = address.City;
            this.Street = address.Street;
            this.PhoneNumber = address.PhoneNumber;
        }
    }
}
