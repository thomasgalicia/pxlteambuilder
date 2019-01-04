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
        public int MaxStudentPerGroup { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
