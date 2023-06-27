using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class ZipCodeCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public ZipCodeCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Zip Code CRUD")]
        [Trait("CRUD", "ZipCodeEntity")]
        public async Task Is_Possible_Do_Zip_Code_CRUD()
        {
            using (var context = _serviceProvider.GetService<ApiContext>())
            {
                ZipCodeImplementation _repository = new ZipCodeImplementation(context);
                CityImplementation _cityRepository = new CityImplementation(context);
                Faker faker = new Faker();
                CityEntity _cityEntity = new CityEntity
                {
                    Name = faker.Address.City(),
                    IbgeCode = faker.Random.Number(1000000, 9999999),
                    SiId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _createdRegister = await _cityRepository.InsertAsync(_cityEntity);
                Assert.NotNull(_createdRegister);
                Assert.Equal(_cityEntity.Name, _createdRegister.Name);
                Assert.Equal(_cityEntity.IbgeCode, _createdRegister.IbgeCode);
                Assert.Equal(_cityEntity.SiId, _createdRegister.SiId);
                Assert.False(_createdRegister.Id == Guid.Empty);

                ZipCodeEntity _entity = new ZipCodeEntity
                {
                    ZipCode = "13.481-001",
                    Street = faker.Address.StreetName(),
                    Number = "0 até 2000",
                    CityId = _createdRegister.Id
                };

                var _createdRegisterZipCode = await _repository.InsertAsync(_entity);
                Assert.NotNull(_createdRegisterZipCode);
                Assert.Equal(_createdRegisterZipCode.ZipCode, _entity.ZipCode);
                Assert.Equal(_createdRegisterZipCode.Street, _entity.Street);
                Assert.Equal(_createdRegisterZipCode.Number, _entity.Number);
                Assert.Equal(_createdRegisterZipCode.CityId, _entity.CityId);
                Assert.False(_createdRegisterZipCode.Id == Guid.Empty);

                _entity.Id = _createdRegisterZipCode.Id;
                _entity.Street = faker.Address.StreetName();
                var _updatedRegister = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_updatedRegister);
                Assert.Equal(_updatedRegister.ZipCode, _createdRegisterZipCode.ZipCode);
                Assert.Equal(_updatedRegister.Street, _createdRegisterZipCode.Street);
                Assert.Equal(_updatedRegister.Number, _createdRegisterZipCode.Number);
                Assert.Equal(_updatedRegister.CityId, _createdRegisterZipCode.CityId);
                Assert.True(_updatedRegister.Id == _entity.Id);

                var _registerExists = await _repository.ExistAsync(_updatedRegister.Id);
                Assert.True(_registerExists);

                var _selectedRegister = await _repository.SelectAsync(_updatedRegister.Id);
                Assert.NotNull(_selectedRegister);
                Assert.Equal(_selectedRegister.ZipCode, _updatedRegister.ZipCode);
                Assert.Equal(_selectedRegister.Street, _updatedRegister.Street);
                Assert.Equal(_selectedRegister.Number, _updatedRegister.Number);
                Assert.Equal(_selectedRegister.CityId, _updatedRegister.CityId);

                _selectedRegister = await _repository.SelectAsync(_updatedRegister.ZipCode);
                Assert.NotNull(_selectedRegister);
                Assert.Equal(_selectedRegister.ZipCode, _updatedRegister.ZipCode);
                Assert.Equal(_selectedRegister.Street, _updatedRegister.Street);
                Assert.Equal(_selectedRegister.Number, _updatedRegister.Number);
                Assert.Equal(_selectedRegister.CityId, _updatedRegister.CityId);
                Assert.NotNull(_selectedRegister.City);
                Assert.NotNull(_selectedRegister.City.Si);

                var _allRegisters = await _repository.SelectAsync();
                Assert.NotNull(_allRegisters);
                Assert.True(_allRegisters.Count() > 0);

                var _deleted = await _repository.DeleteAsync(_selectedRegister.Id);
                Assert.True(_deleted);

                _allRegisters = await _repository.SelectAsync();
                Assert.NotNull(_allRegisters);
                Assert.True(_allRegisters.Count() == 0);
            }
        }
    }
}