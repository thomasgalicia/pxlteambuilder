using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Model
{
    public class LoginResponseModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

    }
}
