using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.User;
using Travel.Domain.Entities;
using Travel.identity.Helpers;
using Travel.Identity.Helpers;

namespace Travel.Identity.Services
{
    /// <summary>
    /// The preceding block of code is the implementation of IUserService.cs 
    /// This implementation authenticates User by checking whether the user exists 
    /// in the database.However, we hardcoded the user object here to simplify the
    /// implementation:
    /// </summary>

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Yourname",
                LastName = "Yoursurname",
                Username = "yoursuperhero",
                Password = "Pass123!"
            }
        };

        private readonly AuthSettings _authSettings;
        public UserService(IOptions<AuthSettings> appSettings) => _authSettings = appSettings.Value;

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
                return null;

            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        /// <summary>
        /// The GenerateJwtToken method generates a JWT by using the value of Secret
        /// in the appsettings.json file.It also uses JwtSecurityTokenHandler
        /// and SecurityTokenDescriptor, which create the claims or payload of
        /// the token.You will notice here that SecurityTokenDescriptor invokes
        /// SigningCredentials with key and algorithm arguments to sign the token.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        private string GenerateJwtToken(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}