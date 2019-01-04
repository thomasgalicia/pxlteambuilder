using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class UserProjects
    {
        public string Email { get; set; }
        public User User { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
