using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class Group
    {
        private ICollection<User> teamMembers = new List<User>();

        public string GroupId { get; set; }
        public string Name { get; set; }
        public string ProjectId { get; set; }

        //navigation properties
        [JsonIgnore]
        public virtual ICollection<UserProjectDetail> UserProjectDetails { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; }

        //non database properties
        public ICollection<User> TeamMembers
        {
            get
            {
                return this.teamMembers;
            }

            set
            {
                this.teamMembers = value;
            }
        }
    }
}
