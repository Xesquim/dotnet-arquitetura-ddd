using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.ZipCode;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.ZipCode
{
    public class WhenRequestZipCode : BaseIntegration
    {
        [Fact]
        public async Task Is_Possible_Realize_Crud_Zip_Code()
        {
            await AddToken();


            //Post City
            var cityDto = new CityDto
            {
                Name = "São Paulo",
                IbgeCode = 3550308,
                SiId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            var response = await PostJsonAsync(cityDto, $"{hostApi}v1/cities", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var cityPostRegister = JsonConvert.DeserializeObject<CityDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("São Paulo", cityPostRegister.Name);
            Assert.Equal(3550308, cityPostRegister.IbgeCode);
            Assert.True(cityPostRegister.Id != default(Guid));

            //Post Zip Code
            var zipCodeDto = new ZipCodeDto
            {
                ZipCode = "13480180",
                Street = "Rua teste",
                Number = "Até 200",
                CityId = cityPostRegister.Id
            };

            response = await PostJsonAsync(zipCodeDto, $"{hostApi}v1/zipcode", client);
            postResult = await response.Content.ReadAsStringAsync();
            var postRegister = JsonConvert.DeserializeObject<ZipCodeDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("13480180", postRegister.ZipCode);
            Assert.Equal("Rua teste", postRegister.Street);
            Assert.Equal("Até 200", postRegister.Number);
            Assert.Equal(cityPostRegister.Id, postRegister.CityId);

            //Put
            var updateZipCodeDto = new ZipCodeDtoUpdate
            {
                Id = postRegister.Id,
                ZipCode = "13480180",
                Street = "Rua bom teste",
                Number = "Até 400",
                CityId = cityPostRegister.Id
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateZipCodeDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}v1/zipcode", stringContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var updatedRegister = JsonConvert.DeserializeObject<ZipCodeDtoUpdateResult>(jsonResult);
            Assert.Equal(updateZipCodeDto.Street, updatedRegister.Street);
            Assert.Equal(updateZipCodeDto.Number, updatedRegister.Number);

            //Get by id
            var id = updatedRegister.Id;
            response = await client.GetAsync($"{hostApi}v1/zipcode/byId/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var selectedRegister = JsonConvert.DeserializeObject<ZipCodeDto>(jsonResult);
            Assert.NotNull(selectedRegister);
            Assert.Equal(updatedRegister.ZipCode, updatedRegister.ZipCode);
            Assert.Equal(updatedRegister.Street, updatedRegister.Street);
            Assert.Equal(updatedRegister.Number, updatedRegister.Number);
            Assert.Equal(updatedRegister.CityId, updatedRegister.CityId);

            //Get by zipCode
            response = await client.GetAsync($"{hostApi}v1/zipcode/{updatedRegister.ZipCode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            selectedRegister = JsonConvert.DeserializeObject<ZipCodeDto>(jsonResult);
            Assert.NotNull(selectedRegister);
            Assert.Equal(updatedRegister.ZipCode, updatedRegister.ZipCode);
            Assert.Equal(updatedRegister.Street, updatedRegister.Street);
            Assert.Equal(updatedRegister.Number, updatedRegister.Number);
            Assert.Equal(updatedRegister.CityId, updatedRegister.CityId);

            //Delete
            response = await client.DeleteAsync($"{hostApi}v1/zipcode/{selectedRegister.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get by id after deleted
            response = await client.GetAsync($"{hostApi}v1/zipcode/{selectedRegister.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}