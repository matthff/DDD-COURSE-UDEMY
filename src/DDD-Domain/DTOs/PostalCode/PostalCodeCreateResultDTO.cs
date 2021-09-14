using System;

namespace DDD_Domain.DTOs.PostalCode
{
    public class PostalCodeCreateResultDTO
    {
        public Guid Id { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }
    
        public string StreetNumber { get; set; }

        public Guid CityId { get; set; } 
        
        public DateTime CreatedAt { get; set;}
    }
}