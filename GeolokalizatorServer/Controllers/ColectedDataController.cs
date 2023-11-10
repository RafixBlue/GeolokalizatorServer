using GeolokalizatorServer.Models;
using GeolokalizatorServer.Services;
using GeolokalizatorServer.Services.Interfaces;
using GeolokalizatorSerwer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Controllers
{
    [Route("geolokalizator/data")]
    [ApiController]
    [Authorize]
    public class ColectedDataController : ControllerBase
    {
        public readonly ICollectedDataService _collectedDataService;

        public ColectedDataController(ICollectedDataService collectedDataService)
        {
            _collectedDataService = collectedDataService;
            
        }

        [HttpGet("hour")]
        public ActionResult<IEnumerable<CollectedDataMapDto>> GetDataForMapHour([FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int hour, [FromQuery] string timezone, [FromQuery] string user)
        {
            var data = _collectedDataService.CollectedDataHour(year, month, day, hour, timezone,user);

            return Ok(data);
        }

        [HttpGet("label")]
        public ActionResult<IEnumerable<CollectedDataMapDto>> GetDataForMapLabel([FromQuery] string? place, [FromQuery] string? startTime, [FromQuery] string? description1, [FromQuery] string? description2, [FromQuery] string? description3, [FromQuery] string user)
        {
            var data = _collectedDataService.CollectedDataLabel(place,startTime, description1, description2, description3,user);

            return Ok(data);
        }
       

    }
   
}
