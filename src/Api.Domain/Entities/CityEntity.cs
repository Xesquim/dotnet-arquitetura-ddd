using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        [Required]
        public Guid SiId { get; set; }
        public SiEntity Si { get; set; }
        public IEnumerable<ZipCodeEntity> ZipCodes { get; set; }
    }
}