using System;

namespace DDD_Domain.DTOs.City
{
    public class CityUpdateResultDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        public Guid UfId { get; set; }
        public DateTime UpdatedAt { get; set; }  
    }
}