using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// A lakcím infromációkat azonosítóval együtt tartalmazó adatáviteli objektum.
    /// </summary>
    public class AddressWithIdDto : AddressDto
    {
        /// <summary>
        /// A cím egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        AddressWithIdDto() { }

        public AddressWithIdDto(UserAddress userAddress) : base(userAddress.Address)
        {
            this.Id = userAddress.Id;
        }
    }
}
