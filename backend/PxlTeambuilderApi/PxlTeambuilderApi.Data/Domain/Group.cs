using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class Group
    {

        public string GroupId { get; set; }
        public string Name { get; set; }
        public string ProjectId { get; set; }

        //navigation properties
        [JsonIgnore]
        public virtual ICollection<UserProjectDetail> UserProjectDetails { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; }
    }
}
