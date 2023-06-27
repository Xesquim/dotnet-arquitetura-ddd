using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class SiGets : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public SiGets(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Gets SI")]
        [Trait("GETs", "SiEntity")]
        public async Task Is_Possible_Gets_Si()
        {
            using (var context = _serviceProvider.GetService<ApiContext>())
            {
                SiImplementation _repository = new SiImplementation(context);
                SiEntity _entity = new SiEntity
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Abbreviation = "SP",
                    Name = "São Paulo"
                };

                var _registerExists = await _repository.ExistAsync(_entity.Id);
                Assert.True(_registerExists);

                var _registerSelected = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_entity.Abbreviation, _registerSelected.Abbreviation);
                Assert.Equal(_entity.Name, _registerSelected.Name);

                var _allRegister = await _repository.SelectAsync();
                Assert.NotNull(_allRegister);
                Assert.True(_allRegister.Count() == 27);
            }
        }
    }
}