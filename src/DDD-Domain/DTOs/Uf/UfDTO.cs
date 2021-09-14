using System;
using System.Collections.Generic;
using DDD_Domain.Entities;

namespace DDD_Domain.DTOs.Uf
{
    public class UfDTO
    {
        public Guid Id { get; set; }
        public string FederatedUnit  { get; set; }
        public string Name { get; set; }
    }
}