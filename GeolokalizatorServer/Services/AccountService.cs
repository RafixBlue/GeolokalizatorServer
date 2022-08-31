using GeolokalizatorServer;
using GeolokalizatorServer.Models;
using GeolokalizatorSerwer.Entities;
using GeolokalizatorSerwer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Services
{
    public class AccountService : IAccountService
    {
        private readonly GeolokalizatorDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(GeolokalizatorDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public List<Role> GetAllRoles()
{
            var roles = _dbContext
              .Roles
              .ToList();

            return roles;

        }

        public void RegisterUser(RegisterUserDto dto)
        {
            //Add validations
            var newUser = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                RoleID = dto.RoleID
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users
                .Include(u=>u.Role)
                .FirstOrDefault(u => u.Name == dto.Name);

            if (user is null)
            {
                //throw new BadHttpRequestException("Invalid username or password");
                return "";
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                //throw new BadHttpRequestException("Invalid username or password");
                return "";
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.ID.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiress = DateTime.Now.AddDays(_authenticationSettings.JwtExpierDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expiress,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        

       
    }
}
