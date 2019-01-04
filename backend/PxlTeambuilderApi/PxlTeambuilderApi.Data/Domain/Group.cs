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
        public ICollection<UserGroup> UserGroups { get; set; }
        public Project Project { get; set; }
    }
}
