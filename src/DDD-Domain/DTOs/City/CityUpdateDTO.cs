using System;
using System.ComponentModel.DataAnnotations;

namespace DDD_Domain.DTOs.City
{
    public class CityUpdateDTO
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [StringLength(60, ErrorMessage = "City Name max name lenght is {1} letters")]
        public string Name { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "IBGE Code is invalid")]
        public int IbgeCode { get; set; }

        [Required(ErrorMessage = "UF Code is required")]
        public Guid UfId { get; set; }
    }
}