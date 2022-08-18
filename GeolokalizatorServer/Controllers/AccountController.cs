using GeolokalizatorServer.Models;
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

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {

            var login = _accountService.checkUser(dto);

            return Ok(login);
        }

        //test requests
        [HttpGet("roles")]
        public ActionResult<IEnumerable<Role>> GetAllRoles()
        {
            var allRoles = _accountService.GetAllRoles();
            

            return Ok(allRoles);
        }

        [HttpGet("test")]
        public ActionResult<IEnumerable<Role>> GetTest()// [FromQuery] int userId, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int hour
        {
            //var allRoles = _accountService.GetAllRoles();
            //var test = _accountService.CollectedDataForMap(1, 2008, 3, 1, 7);

            return Ok("test");
        }
    }
}
