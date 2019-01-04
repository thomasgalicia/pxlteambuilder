using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //TODO: implement add
        public async Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

    }
}
