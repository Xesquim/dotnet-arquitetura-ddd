using System;
using Api.Domain.Dtos.Si;

namespace Api.Domain.Dtos.City
{
    public class CityDtoComplete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        public Guid SiId { get; set; }
        public SiDto Si { get; set; }
    }
}