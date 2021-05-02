using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateOrEditAddressDto
    {
        [Required]
        [Range(1000, 9999)]
        public int ZipCode { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(200)]
        public string Street { get; set; }
        [Required]
        [Phone]
        [RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; }
    }
}
