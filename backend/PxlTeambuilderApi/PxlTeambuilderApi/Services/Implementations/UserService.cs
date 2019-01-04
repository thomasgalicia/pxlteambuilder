using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Repositories.Interfaces;
using PxlTeambuilderApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //TODO: throw exception when user not found (=null)
        public Task<User> GetUserByEmailAsync(string email)
        {
            return userRepository.GetUserByEmail(email);
        }

        //TODO: hash password before adding to database
        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
