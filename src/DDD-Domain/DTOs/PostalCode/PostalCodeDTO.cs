using System;
using DDD_Domain.DTOs.City;

namespace DDD_Domain.DTOs.PostalCode
{
    public class PostalCodeDTO
    {
        public Guid Id { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }
    
        public string StreetNumber { get; set; }

        public Guid CityId { get; set; }
        
        public CityCompleteDTO City { get; set; }
    }
}