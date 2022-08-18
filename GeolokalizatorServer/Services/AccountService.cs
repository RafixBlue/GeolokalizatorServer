using GeolokalizatorServer.Models;
using GeolokalizatorSerwer.Entities;
using GeolokalizatorSerwer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Services
{
    public class AccountService : IAccountService
    {
        private readonly GeolokalizatorDbContext _dbContext;

        public AccountService(GeolokalizatorDbContext dbContext)
        {
            _dbContext = dbContext;
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
                PasswordHash = dto.PasswordHash,
                RoleID = dto.RoleID
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public bool checkUser(LoginDto dto)
        {
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Name == dto.Name && u.PasswordHash == dto.PasswordHash);
            
            if(user is null)
            { 
                return false; 
            }

            return true;
        }

       
    }
}
