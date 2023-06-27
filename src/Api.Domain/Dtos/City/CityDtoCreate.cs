using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.City
{
    public class CityDtoCreate
    {
        [Required(ErrorMessage = "City name is required")]
        [StringLength(60, ErrorMessage = "City name is too long")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Invalid IBGE code")]
        public int IbgeCode { get; set; }
        [Required(ErrorMessage = "Si code is required")]
        public Guid SiId { get; set; }
    }
}