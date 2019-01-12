using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class UserProjectDetail
    {
        public int UserId { get; set; }
        public string ProjectId { get; set; }
        public string GroupId { get; set; }

        //navigation properties
        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; }

        [JsonIgnore]
        public virtual Group Group { get; set; }
    }
}
