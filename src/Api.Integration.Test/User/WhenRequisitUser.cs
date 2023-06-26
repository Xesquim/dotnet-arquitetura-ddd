using System;
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

            var response = await PostJsonAsync(userDto, $"{hostApi}v1/users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postRegister = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, postRegister.UserName);
            Assert.Equal(_email, postRegister.Email);
            Assert.False(postRegister.Id == default(Guid));
        }
    }
}