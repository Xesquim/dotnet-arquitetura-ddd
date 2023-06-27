using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.City;
using Api.Domain.Entities;
using Api.Domain.Models.City;
using Bogus;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CityMapper : BaseTestService
    {
        [Fact(DisplayName = "Is possible map the city models")]
        public void Is_Possible_Map_The_City_Models()
        {
            var faker = new Faker();
            var model = new CityModel
            {
                Id = Guid.NewGuid(),
                Name = faker.Address.City(),
                IbgeCode = faker.Random.Number(1000000, 9999999),
                SiId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entityList = new List<CityEntity>();
            for (int i = 0 ; i < 5 ; i++)
            {
                var item = new CityEntity{
                    Id = Guid.NewGuid(),
                    Name = faker.Address.City(),
                    IbgeCode = faker.Random.Number(1000000, 9999999),
                    SiId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Si = new SiEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.State(),
                        Abbreviation = faker.Address.State().Substring(1, 3)
                    }
                };
                entityList.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<CityEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.IbgeCode, model.IbgeCode);
            Assert.Equal(entity.SiId, model.SiId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var cityDto = Mapper.Map<CityDto>(entity);
            Assert.Equal(cityDto.Id, entity.Id);
            Assert.Equal(cityDto.Name, entity.Name);
            Assert.Equal(cityDto.IbgeCode, entity.IbgeCode);
            Assert.Equal(cityDto.SiId, entity.SiId);
            
            var cityDtoComplete = Mapper.Map<CityDtoComplete>(entityList.FirstOrDefault());
            Assert.Equal(cityDtoComplete.Id, entityList.FirstOrDefault().Id);
            Assert.Equal(cityDtoComplete.Name, entityList.FirstOrDefault().Name);
            Assert.Equal(cityDtoComplete.IbgeCode, entityList.FirstOrDefault().IbgeCode);
            Assert.Equal(cityDtoComplete.SiId, entityList.FirstOrDefault().SiId);
            Assert.NotNull(cityDtoComplete.Si);

            var dtoList = Mapper.Map<List<CityDto>>(entityList);
            Assert.True(dtoList.Count() == entityList.Count());
            for(int i = 0 ; i < dtoList.Count() ; i++)
            {
                Assert.Equal(dtoList[i].Id, entityList[i].Id);
                Assert.Equal(dtoList[i].Name, entityList[i].Name);
                Assert.Equal(dtoList[i].IbgeCode, entityList[i].IbgeCode);
                Assert.Equal(dtoList[i].SiId, entityList[i].SiId);
            }

            var cityDtoCreateResult = Mapper.Map<CityDtoCreateResult>(entity);
            Assert.Equal(cityDtoCreateResult.Id, entity.Id);
            Assert.Equal(cityDtoCreateResult.Name, entity.Name);
            Assert.Equal(cityDtoCreateResult.IbgeCode, entity.IbgeCode);
            Assert.Equal(cityDtoCreateResult.SiId, entity.SiId);
            Assert.Equal(cityDtoCreateResult.CreateAt, entity.CreateAt);

            var cityDtoUpdateResult = Mapper.Map<CityDtoUpdateResult>(entity);
            Assert.Equal(cityDtoUpdateResult.Id, entity.Id);
            Assert.Equal(cityDtoUpdateResult.Name, entity.Name);
            Assert.Equal(cityDtoUpdateResult.IbgeCode, entity.IbgeCode);
            Assert.Equal(cityDtoUpdateResult.SiId, entity.SiId);
            Assert.Equal(cityDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto => Model
            var cityModel = Mapper.Map<CityModel>(cityDto);
            Assert.Equal(cityModel.Id, cityDto.Id);
            Assert.Equal(cityModel.Name, cityDto.Name);
            Assert.Equal(cityModel.IbgeCode, cityDto.IbgeCode);
            Assert.Equal(cityModel.SiId, cityDto.SiId);
            
            var cityDtoCreate = Mapper.Map<CityDtoCreate>(cityModel);
            Assert.Equal(cityModel.Name, cityDtoCreate.Name);
            Assert.Equal(cityModel.IbgeCode, cityDtoCreate.IbgeCode);
            Assert.Equal(cityModel.SiId, cityDtoCreate.SiId);
            
            var cityDtoUpdate = Mapper.Map<CityDtoUpdate>(cityModel);
            Assert.Equal(cityModel.Id, cityDtoUpdate.Id);
            Assert.Equal(cityModel.Name, cityDtoUpdate.Name);
            Assert.Equal(cityModel.IbgeCode, cityDtoUpdate.IbgeCode);
            Assert.Equal(cityModel.SiId, cityDtoUpdate.SiId);
        }
    }
}