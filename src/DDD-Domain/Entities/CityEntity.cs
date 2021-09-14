using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD_Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public int IbgeCode { get; set; }

        [Required]
        public Guid UfId { get; set; }
        
        public UfEntity Uf { get; set; }

        public IEnumerable<PostalCodeEntity> PostalCodes { get; set; }
    }
}