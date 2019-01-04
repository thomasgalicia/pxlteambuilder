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

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await context.Users.FindAsync(email);
        }

        //TODO: implement add
        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

    }
}
