using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Model
{
    public class NewGroupInputModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }
    }
}
