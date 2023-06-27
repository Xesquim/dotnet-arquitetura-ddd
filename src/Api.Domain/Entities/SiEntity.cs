using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class SiEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Abbreviation { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public IEnumerable<CityEntity> Cities { get; set; }
    }
}