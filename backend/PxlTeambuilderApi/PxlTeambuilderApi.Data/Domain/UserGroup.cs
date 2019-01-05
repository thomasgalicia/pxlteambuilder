﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Data.Domain
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public string GroupId { get; set; }

        //navigation properties
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }

}
