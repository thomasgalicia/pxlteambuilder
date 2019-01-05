using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class UserProject
    {
        public int UserId { get; set; }
        public string ProjectId { get; set; }

        //navigation properties
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
