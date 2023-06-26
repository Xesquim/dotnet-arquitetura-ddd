using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.User
{
    public class WhenRequisitUser : BaseIntegration
    {
        public string _name { get; set; }

        public string _email { get; set; }
        public string _password { get; set; }

        [Fact]
        public async Task Is_Possible_Realize_User_Crud()
        {
            await AddToken();
            var faker = new Faker();
            _name = faker.Name.FirstName();
            _email = faker.Internet.Email();
            _password = faker.Internet.Password();

            var userDto = new UserDtoCreate()
            {
                UserName = _name,
                Email = _email,
                Password = _password
            };

            //Post Section
            var response = await PostJsonAsync(userDto, $"{hostApi}v1/users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postRegister = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, postRegister.UserName);
            Assert.Equal(_email, postRegister.Email);
            Assert.False(postRegister.Id == default(Guid));

            //Get All Section
            response = await client.GetAsync($"{hostApi}v1/users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() > 0);
            Assert.True(listFromJson.Where(user => user.Id == postRegister.Id).Count() == 1);
        }
    }
}