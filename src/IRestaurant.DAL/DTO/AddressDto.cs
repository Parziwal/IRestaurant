using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class AddressDto
    {
        public int ZipCode { get; }
        public string City { get; }
        public string Street { get; }
        public string PhoneNumber { get; }

        public AddressDto(AddressOwned address)
        {
            this.ZipCode = address.ZipCode;
            this.City = address.City;
            this.Street = address.Street;
            this.PhoneNumber = address.PhoneNumber;
        }
    }
}
