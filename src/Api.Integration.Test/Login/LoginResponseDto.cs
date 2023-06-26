using System;
using Newtonsoft.Json;

namespace Api.Integration.Test.Login
{
    public class LoginResponseDto
    {
        [JsonProperty("authenticated")]
        public bool authenticated { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("expiration")]
        public DateTime expiration { get; set; }

        [JsonProperty("accessToken")]
        public string accessToken { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}