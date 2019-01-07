using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Interfaces
{
    public interface IPasswordService
    {

        string GenerateHash(string rawPassword);

        bool IsSame(string rawPassword, string hashPassword);
    }
}
