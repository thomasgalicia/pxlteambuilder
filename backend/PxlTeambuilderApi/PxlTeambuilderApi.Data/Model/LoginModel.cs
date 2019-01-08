using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PxlTeambuilderApi.Data.Model
{
    public class LoginModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
