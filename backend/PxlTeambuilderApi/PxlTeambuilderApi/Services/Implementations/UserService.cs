using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Repositories.Interfaces;
using PxlTeambuilderApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Exceptions;
using PxlTeambuilderApi.Services.Abstract;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class UserService : LogComponent, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //TODO: throw exception when user not found (=null)
        public async Task<User> GetUserByUserIdAsync(int userId)
        {
            return await userRepository.GetUserByUserIdAsync(userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = await userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        //TODO: hash password before adding to database
        public async Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}