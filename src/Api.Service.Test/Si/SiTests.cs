using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Si;
using Bogus;

namespace Api.Service.Test.Si
{
    public class SiTests
    {
        public static string Name { get; set; }
        public static string Abbreviation { get; set; }
        public static Guid SiId { get; set; }
        public List<SiDto> SiDtoList { get; set; } = new List<SiDto>();
        public SiDto SiDto;
        public Faker faker = new Faker();

        public SiTests()
        {
            SiId = Guid.NewGuid();
            Abbreviation = faker.Address.State().Substring(1, 3);
            Name = faker.Address.State();

            for (int i = 0 ; i < 10 ; i++)
            {
                var dto = new SiDto
                {
                    Id = Guid.NewGuid(),
                    Abbreviation = faker.Address.State().Substring(1, 3),
                    Name = faker.Address.State()
                };
                SiDtoList.Add(dto);
            }

            SiDto = new SiDto
            {
                    Id = SiId,
                    Abbreviation = Abbreviation,
                    Name = Name
            };
        }
    }
}