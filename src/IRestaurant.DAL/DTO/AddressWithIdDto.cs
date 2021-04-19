using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
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
