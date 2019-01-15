using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Model
{
    public class UpdateGroupModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("oldGroupId")]
        public string OldGroupId { get; set; }

        [JsonProperty("newGroupId")]
        public string NewGroupId { get; set; }

    }
}
