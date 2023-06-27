using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoCreate
    {
        [Required(ErrorMessage = "Zip Code is required")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }
        public string Number { get; set; }
        [Required(ErrorMessage = "City is required")]
        public Guid CityId { get; set; }
    }
}