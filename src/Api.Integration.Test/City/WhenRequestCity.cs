using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.City
{
    public class WhenRequestCity : BaseIntegration
    {
        [Fact]
        public async Task Is_Possible_Realize_Crud_City()
        {
            await AddToken();

            var cityDto = new CityDto
            {
                Name = "São Paulo",
                IbgeCode = 3550308,
                SiId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //Post
            var response = await PostJsonAsync(cityDto, $"{hostApi}v1/cities", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postRegister = JsonConvert.DeserializeObject<CityDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("São Paulo", postRegister.Name);
            Assert.Equal(3550308, postRegister.IbgeCode);
            Assert.True(postRegister.Id != default(Guid));

            //Get All
            response = await client.GetAsync($"{hostApi}v1/cities");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<CityDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() > 0);
            Assert.True(listFromJson.Where(city => city.Id == postRegister.Id).Count() == 1);

            //Put
            var updateCityDto = new CityDtoUpdate
            {
                Id = postRegister.Id,
                Name = "Limeira",
                IbgeCode = 3526902,
                SiId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateCityDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}v1/cities", stringContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var updatedRegister = JsonConvert.DeserializeObject<CityDtoUpdateResult>(jsonResult);
            Assert.Equal("Limeira", updatedRegister.Name);
            Assert.Equal(3526902, updatedRegister.IbgeCode);

            //Get by id
            var id = updatedRegister.Id;
            response = await client.GetAsync($"{hostApi}v1/cities/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var selectedRegister = JsonConvert.DeserializeObject<CityDto>(jsonResult);
            Assert.NotNull(selectedRegister);
            Assert.Equal("Limeira", selectedRegister.Name);
            Assert.Equal(3526902, selectedRegister.IbgeCode);

            //Get complete by id
            response = await client.GetAsync($"{hostApi}v1/cities/complete/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var completeSelectedRegister = JsonConvert.DeserializeObject<CityDtoComplete>(jsonResult);
            Assert.NotNull(completeSelectedRegister);
            Assert.Equal("Limeira", completeSelectedRegister.Name);
            Assert.Equal(3526902, completeSelectedRegister.IbgeCode);
            Assert.NotNull(completeSelectedRegister.Si);

            //Get by ibgeCode
            var ibgeCode = updatedRegister.IbgeCode;
            response = await client.GetAsync($"{hostApi}v1/cities/ibge/{ibgeCode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            completeSelectedRegister = JsonConvert.DeserializeObject<CityDtoComplete>(jsonResult);
            Assert.NotNull(completeSelectedRegister);
            Assert.Equal("Limeira", completeSelectedRegister.Name);
            Assert.Equal(3526902, completeSelectedRegister.IbgeCode);
            Assert.NotNull(completeSelectedRegister.Si);

            //Delete
            response = await client.DeleteAsync($"{hostApi}v1/cities/{selectedRegister.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get by id after deleted
            response = await client.GetAsync($"{hostApi}v1/cities/{selectedRegister.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}