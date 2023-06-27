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
    public class CityCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public CityCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "City CRUD")]
        [Trait("CRUD", "CityEntity")]
        public async Task Is_Possible_Do_City_CRUD()
        {
            using (var context = _serviceProvider.GetService<ApiContext>())
            {
                CityImplementation _repository = new CityImplementation(context);
                Faker faker = new Faker();
                CityEntity _entity = new CityEntity
                {
                    Name = faker.Address.City(),
                    IbgeCode = faker.Random.Number(1000000, 9999999),
                    SiId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _createdRegister = await _repository.InsertAsync(_entity);
                Assert.NotNull(_createdRegister);
                Assert.Equal(_entity.Name, _createdRegister.Name);
                Assert.Equal(_entity.IbgeCode, _createdRegister.IbgeCode);
                Assert.Equal(_entity.SiId, _createdRegister.SiId);
                Assert.False(_createdRegister.Id == Guid.Empty);

                _entity.Name = faker.Address.City();
                _entity.Id = _createdRegister.Id;
                var _updatedRegister = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_updatedRegister);
                Assert.Equal(_entity.Name, _updatedRegister.Name);
                Assert.Equal(_entity.IbgeCode, _updatedRegister.IbgeCode);
                Assert.Equal(_entity.SiId, _updatedRegister.SiId);

                var _registerExists = await _repository.ExistAsync(_updatedRegister.Id);
                Assert.True(_registerExists);

                var _selectedRegister = await _repository.SelectAsync(_updatedRegister.Id);
                Assert.NotNull(_selectedRegister);
                Assert.Equal(_selectedRegister.Name, _updatedRegister.Name);
                Assert.Equal(_selectedRegister.IbgeCode, _updatedRegister.IbgeCode);
                Assert.Equal(_selectedRegister.SiId, _updatedRegister.SiId);
                Assert.Null(_selectedRegister.Si);

                _selectedRegister = await _repository.GetCompleteByIbge(_updatedRegister.IbgeCode);
                Assert.NotNull(_selectedRegister);
                Assert.Equal(_selectedRegister.Name, _updatedRegister.Name);
                Assert.Equal(_selectedRegister.IbgeCode, _updatedRegister.IbgeCode);
                Assert.Equal(_selectedRegister.SiId, _updatedRegister.SiId);
                Assert.NotNull(_selectedRegister.Si);

                _selectedRegister = await _repository.GetCompleteById(_updatedRegister.Id);
                Assert.NotNull(_selectedRegister);
                Assert.Equal(_selectedRegister.Name, _updatedRegister.Name);
                Assert.Equal(_selectedRegister.IbgeCode, _updatedRegister.IbgeCode);
                Assert.Equal(_selectedRegister.SiId, _updatedRegister.SiId);
                Assert.NotNull(_selectedRegister.Si);

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