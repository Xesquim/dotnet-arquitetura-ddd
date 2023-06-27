using System;

namespace Api.Domain.Dtos.City
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IbgeCode { get; set; }
        public Guid SiId { get; set; }
    }
}