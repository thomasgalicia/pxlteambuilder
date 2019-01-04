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

        public User GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(user => user.Email == email);
        }

        //TODO: implement add
        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
