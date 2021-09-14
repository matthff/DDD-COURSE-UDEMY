using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD_Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string FederatedUnit  { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        
        public IEnumerable<CityEntity> Cities { get; set; }
    }
}