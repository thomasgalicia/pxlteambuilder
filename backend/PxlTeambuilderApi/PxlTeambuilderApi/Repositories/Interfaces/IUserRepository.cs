﻿using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        User AddUser(User user);
    }
}
