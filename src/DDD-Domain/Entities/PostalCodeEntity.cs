using System;
using System.ComponentModel.DataAnnotations;

namespace DDD_Domain.Entities
{
    public class PostalCodeEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string StreetNumber { get; set; }
        
        [Required]
        public Guid CityId { get; set; }

        public CityEntity City { get; set; }
    }
}