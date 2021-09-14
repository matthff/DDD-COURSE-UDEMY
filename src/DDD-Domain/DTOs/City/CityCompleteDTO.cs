using System;
using DDD_Domain.DTOs.Uf;

namespace DDD_Domain.DTOs.City
{
    public class CityCompleteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        public Guid UfId { get; set; }
        public UfDTO Uf { get; set; }
    }
}