using GeolokalizatorSerwer.Controllers;
using GeolokalizatorSerwer.Entities;
using GeolokalizatorServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Controllers
{
    [Route("geolokalizator/time")]
    [ApiController]
    public class CollectionTimeController : ControllerBase
    {
        private readonly ICollectionTimeService _timeService;

        public CollectionTimeController(ICollectionTimeService time)
        {
            _timeService = time;
        }

        [HttpGet("year")]
        public ActionResult<IEnumerable<Location>> GetAvailableYears([FromQuery]int userId)
        {
            var availableYears = _timeService.GetAvailableYears(userId);

            return Ok(availableYears);
        }

        [HttpGet("month")]
        public ActionResult<IEnumerable<Location>> GetAvailableMonths([FromQuery]int userId, [FromQuery]int year)
        {
            var availableYears = _timeService.GetAvailableMonths(userId,year);

            return Ok(availableYears);
        }

        [HttpGet("day")]
        public ActionResult<IEnumerable<Location>> GetAvailableDays([FromQuery]int userId, [FromQuery]int year, [FromQuery]int month)
        {
            var availableYears = _timeService.GetAvailableDays(userId,year,month);

            return Ok(availableYears);
        }

        [HttpGet("hour")]
        public ActionResult<IEnumerable<Location>> GetAvailableHours([FromQuery]int userId, [FromQuery]int year, [FromQuery]int month, [FromQuery]int day)
        {
            var availableYears = _timeService.GetAvailableHours(userId, year, month, day);

            return Ok(availableYears);
        }

    }
}
