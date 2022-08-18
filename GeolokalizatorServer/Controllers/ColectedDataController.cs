using GeolokalizatorServer.Models;
using GeolokalizatorServer.Services;
using GeolokalizatorServer.Services.Interfaces;
using GeolokalizatorSerwer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Controllers
{
    [Route("geolokalizator/data")]
    [ApiController]
    public class ColectedDataController : ControllerBase
    {
        public readonly ICollectedDataService _collectedDataService;

        public ColectedDataController(ICollectedDataService collectedDataService)
        {
            _collectedDataService = collectedDataService;
        }

        [HttpGet("map/hour")]
        public ActionResult<IEnumerable<CollectedDataMapDto>> GetDataForMapHour([FromQuery] int userId, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int hour)
{
            var mapData = _collectedDataService.CollectedDataMapHour(userId, year, month, day, hour);

            return Ok(mapData);
        }

        [HttpGet("graph/hour")]
        public ActionResult<IEnumerable<CollectedDataGraphDto>> GetDataForGraphHour([FromQuery] int userId, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int hour)
        {
            var graphData = _collectedDataService.CollectedDataGraphHour(userId, year, month, day, hour);
            
            return Ok(graphData);
        }

    }
}
