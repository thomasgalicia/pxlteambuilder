﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class Project
    {
        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("maxstudentspergroup")]
        public int MaxStudentsPerGroup { get; set; }

        //navigation properties
        public ICollection<Group> Groups { get; set; }
        public User User { get; set; }
    }
}
