using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using Api.Domain.Models.ZipCode;
using Bogus;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class ZipCodeMapper : BaseTestService
    {
        [Fact(DisplayName = "Is possible map the zip code models")]
        public void Is_Possible_Map_The_Zip_Code_Models()
        {
            var faker = new Faker();
            var model = new ZipCodeModel
            {
                Id = Guid.NewGuid(),
                ZipCode = faker.Random.Number(1, 10000).ToString(),
                Street = faker.Address.StreetName(),
                Number = "",
                CityId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entityList = new List<ZipCodeEntity>();
            for (int i = 0 ; i < 5 ; i++)
            {
                var item = new ZipCodeEntity{
                    Id = Guid.NewGuid(),
                    ZipCode = faker.Random.Number(1, 10000).ToString(),
                    Street = faker.Address.StreetName(),
                    Number = "",
                    CityId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    City = new CityEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.City(),
                        IbgeCode = faker.Random.Number(1000000, 9999999),
                        SiId = Guid.NewGuid(),
                        Si = new SiEntity
                        {
                            Id = Guid.NewGuid(),
                            Name = faker.Address.State(),
                            Abbreviation = faker.Address.State().Substring(1, 3)
                        }
                    }
                };
                entityList.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<ZipCodeEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.ZipCode, model.ZipCode);
            Assert.Equal(entity.Street, model.Street);
            Assert.Equal(entity.Number, model.Number);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var zipCodeDto = Mapper.Map<ZipCodeDto>(entity);
            Assert.Equal(zipCodeDto.Id, entity.Id);
            Assert.Equal(zipCodeDto.ZipCode, entity.ZipCode);
            Assert.Equal(zipCodeDto.Street, entity.Street);
            Assert.Equal(zipCodeDto.Number, entity.Number);
            
            var zipCodeDtoComplete = Mapper.Map<ZipCodeDto>(entityList.FirstOrDefault());
            Assert.Equal(zipCodeDtoComplete.Id, entityList.FirstOrDefault().Id);
            Assert.Equal(zipCodeDtoComplete.ZipCode, entityList.FirstOrDefault().ZipCode);
            Assert.Equal(zipCodeDtoComplete.Street, entityList.FirstOrDefault().Street);
            Assert.Equal(zipCodeDtoComplete.Number, entityList.FirstOrDefault().Number);
            Assert.NotNull(zipCodeDtoComplete.City);
            Assert.NotNull(zipCodeDtoComplete.City.Si);

            var dtoList = Mapper.Map<List<ZipCodeDto>>(entityList);
            Assert.True(dtoList.Count() == entityList.Count());
            for(int i = 0 ; i < dtoList.Count() ; i++)
            {
                Assert.Equal(dtoList[i].Id, entityList[i].Id);
                Assert.Equal(dtoList[i].ZipCode, entityList[i].ZipCode);
                Assert.Equal(dtoList[i].Street, entityList[i].Street);
                Assert.Equal(dtoList[i].Number, entityList[i].Number);
            }

            var zipCodeDtoCreateResult = Mapper.Map<ZipCodeDtoCreateResult>(entity);
            Assert.Equal(zipCodeDtoCreateResult.Id, entity.Id);
            Assert.Equal(zipCodeDtoCreateResult.ZipCode, entity.ZipCode);
            Assert.Equal(zipCodeDtoCreateResult.Street, entity.Street);
            Assert.Equal(zipCodeDtoCreateResult.Number, entity.Number);
            Assert.Equal(zipCodeDtoCreateResult.CreateAt, entity.CreateAt);

            var zipCodeDtoUpdateResult = Mapper.Map<ZipCodeDtoUpdateResult>(entity);
            Assert.Equal(zipCodeDtoUpdateResult.Id, entity.Id);
            Assert.Equal(zipCodeDtoUpdateResult.ZipCode, entity.ZipCode);
            Assert.Equal(zipCodeDtoUpdateResult.Street, entity.Street);
            Assert.Equal(zipCodeDtoUpdateResult.Number, entity.Number);
            Assert.Equal(zipCodeDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto => Model
            var zipCodeModel = Mapper.Map<ZipCodeModel>(zipCodeDto);
            Assert.Equal(zipCodeModel.Id, zipCodeDto.Id);
            Assert.Equal(zipCodeModel.ZipCode, zipCodeDto.ZipCode);
            Assert.Equal(zipCodeModel.Street, zipCodeDto.Street);
            Assert.Equal("S/N", zipCodeModel.Number);
            
            var zipCodeDtoCreate = Mapper.Map<ZipCodeDtoCreate>(zipCodeModel);
            Assert.Equal(zipCodeModel.ZipCode, zipCodeDtoCreate.ZipCode);
            Assert.Equal(zipCodeModel.Street, zipCodeDtoCreate.Street);
            Assert.Equal(zipCodeModel.Number, zipCodeDtoCreate.Number);
            
            var zipCodeDtoUpdate = Mapper.Map<ZipCodeDtoUpdate>(zipCodeModel);
            Assert.Equal(zipCodeModel.Id, zipCodeDtoUpdate.Id);
            Assert.Equal(zipCodeModel.ZipCode, zipCodeDtoUpdate.ZipCode);
            Assert.Equal(zipCodeModel.Street, zipCodeDtoUpdate.Street);
            Assert.Equal(zipCodeModel.Number, zipCodeDtoUpdate.Number);
        }
    }
}