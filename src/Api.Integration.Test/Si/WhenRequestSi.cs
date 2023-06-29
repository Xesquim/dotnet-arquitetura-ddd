using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Si;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Si
{
    public class WhenRequestSi : BaseIntegration
    {
        [Fact]
        public async Task Is_Possible_Realize_Get_Si()
        {
            await AddToken();

            //Get all
            response = await client.GetAsync($"{hostApi}v1/sis");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<SiDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() == 27);
            Assert.True(listFromJson.Where(si => si.Abbreviation == "SP").Count() == 1);

            var id = listFromJson.Where(si => si.Abbreviation == "SP").FirstOrDefault().Id;

            //Get by id
            response = await client.GetAsync($"{hostApi}v1/sis/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var selectedRegister = JsonConvert.DeserializeObject<SiDto>(jsonResult);
            Assert.NotNull(selectedRegister);
            Assert.Equal("São Paulo", selectedRegister.Name);
            Assert.Equal("SP", selectedRegister.Abbreviation);
        }
    }
}