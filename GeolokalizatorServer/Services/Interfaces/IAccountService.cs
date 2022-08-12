using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Services.Interfaces
{
    public interface IAccountService
    {
        List<Role> GetAllRoles();
    }
}
