using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Model
{
    public class ParticipateInputModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }

    }
}
