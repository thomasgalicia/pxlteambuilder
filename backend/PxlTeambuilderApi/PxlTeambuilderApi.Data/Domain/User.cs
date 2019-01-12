using Newtonsoft.Json;
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
        public UserRole Role { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        //navigation properties
        [JsonIgnore]
        public virtual ICollection<UserProjectDetail> UserProjectDetails { get; set; }

        [JsonIgnore]
        public virtual ICollection<Project> CreatedProjects { get; set; }
    }
}
