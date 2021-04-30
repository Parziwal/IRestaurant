using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Addresses
{
    public class AddressWithIdDto : AddressDto
    {
        public int Id { get; set; }
        public AddressWithIdDto(UserAddress userAddress) : base(userAddress.Address)
        {
            this.Id = userAddress.Id;
        }
    }
}
