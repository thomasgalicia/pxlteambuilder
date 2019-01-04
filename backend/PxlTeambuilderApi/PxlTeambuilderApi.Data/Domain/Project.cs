using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxStudentsPerGroup { get; set; }

        //public virtual ICollection<UserProjects> UserProjects { get; set; }

        //navigation properties
        public ICollection<Group> Groups { get; set; }
    }
}
