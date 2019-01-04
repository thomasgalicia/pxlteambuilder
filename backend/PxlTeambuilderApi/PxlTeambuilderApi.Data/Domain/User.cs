using PxlTeambuilderApi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        //navigation properties
        public ICollection<UserGroup> UserGroups { get; set; } 
        public ICollection<Project> Projects { get; set; }
    }
}
