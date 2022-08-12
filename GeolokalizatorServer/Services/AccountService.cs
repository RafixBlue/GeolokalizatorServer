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
    }
}
