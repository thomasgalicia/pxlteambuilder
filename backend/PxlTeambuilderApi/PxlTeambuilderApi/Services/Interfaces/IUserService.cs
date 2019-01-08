using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByUserIdAsync(int userId);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUserAsync(User user);
    }
}
