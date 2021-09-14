using System;
using System.ComponentModel.DataAnnotations;

namespace DDD_Domain.DTOs.PostalCode
{
    public class PostalCodeUpdateDTO
    {
        
        [Required(ErrorMessage ="Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "PostalCode is required")]
        [MaxLength(10, ErrorMessage = "PostalCode must be {1} digits max")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(60, ErrorMessage = "Address must be {1} digits max")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "StreetNumber is required")]
        [MaxLength(10, ErrorMessage = "StreetNumber must be {1} digits max")]
        public string StreetNumber { get; set; }
        
        [Required(ErrorMessage ="CityId is required")]
        public Guid CityId { get; set; }
    }
}