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
