using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PxlTeambuilderApi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly PxlTeamBuilderContext context;

        public UserRepository(PxlTeamBuilderContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserByUserIdAsync(int userId)
        {
            return await context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(user => user.Email == email.ToLower());
        }

        //TODO: implement add
        public async Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

    }
}
