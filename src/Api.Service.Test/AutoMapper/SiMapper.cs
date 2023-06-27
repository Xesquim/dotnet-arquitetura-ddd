using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Si;
using Api.Domain.Entities;
using Api.Domain.Models.Si;
using Bogus;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class SiMapper : BaseTestService
    {
        [Fact(DisplayName = "Is possible map the si models")]
        public void Is_Possible_Map_The_Si_Models()
        {
            var faker = new Faker();
            var model = new SiModel
            {
                Id = Guid.NewGuid(),
                Name = faker.Address.State(),
                Abbreviation = faker.Address.State().Substring(1, 3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entityList = new List<SiEntity>();
            for (int i = 0 ; i < 5 ; i++)
            {
                var item = new SiEntity{
                    Id = Guid.NewGuid(),
                    Name = faker.Address.State(),
                    Abbreviation = faker.Address.State().Substring(1, 3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                entityList.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<SiEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Abbreviation, model.Abbreviation);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var siDto = Mapper.Map<SiDto>(entity);
            Assert.Equal(siDto.Id, entity.Id);
            Assert.Equal(siDto.Name, entity.Name);
            Assert.Equal(siDto.Abbreviation, entity.Abbreviation);

            var dtoList = Mapper.Map<List<SiDto>>(entityList);
            Assert.True(dtoList.Count() == entityList.Count());
            for(int i = 0 ; i < dtoList.Count() ; i++)
            {
                Assert.Equal(dtoList[i].Id, entityList[i].Id);
                Assert.Equal(dtoList[i].Name, entityList[i].Name);
                Assert.Equal(dtoList[i].Abbreviation, entityList[i].Abbreviation);
            }

            //Dto => Model
            var siModel = Mapper.Map<SiModel>(siDto);
            Assert.Equal(siModel.Id, siDto.Id);
            Assert.Equal(siModel.Name, siDto.Name);
            Assert.Equal(siModel.Abbreviation, siDto.Abbreviation);
        }
    }
}