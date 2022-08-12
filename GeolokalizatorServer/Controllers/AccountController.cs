using GeolokalizatorSerwer.Entities;
using GeolokalizatorSerwer.Services;
using GeolokalizatorSerwer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Controllers
{
    [Route("geolokalizator/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
 
        private readonly IAccountService _accountService;

        public AccountController(IAccountService account)
        {
            _accountService = account;
        }

        [HttpGet("roles")]
        public ActionResult<IEnumerable<Role>> GetAllRoles()
        {
            var allRoles = _accountService.GetAllRoles();
            

            return Ok(allRoles);
        }

        [HttpGet("test")]
        public ActionResult<IEnumerable<Role>> GetTest()
        {
            //var allRoles = _accountService.GetAllRoles();


            return Ok("test");
        }
    }
}
