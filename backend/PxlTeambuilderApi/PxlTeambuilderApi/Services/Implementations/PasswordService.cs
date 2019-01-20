using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PxlTeambuilderApi.Services.Abstract;
using PxlTeambuilderApi.Services.Interfaces;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class PasswordService: LogComponent, IPasswordService
    {
        

        public string GenerateHash(string rawPassword)
        {
            
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
               byte[] textData = System.Text.Encoding.UTF8.GetBytes(rawPassword);
               byte[] hash = sha.ComputeHash(textData);
               return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
            
        }

        public bool IsSame(string rawPassword, string hashPassword)
        {
            string generatedHash = GenerateHash(rawPassword);
            return generatedHash == hashPassword;
        }
    }
}
