using GeolokalizatorServer.Models;
using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Services.Interfaces
{
    public interface IAccountService
    {
        public List<Role> GetAllRoles();
        public bool checkUser(LoginDto dto);
        public void RegisterUser(RegisterUserDto dto);
    }
}
