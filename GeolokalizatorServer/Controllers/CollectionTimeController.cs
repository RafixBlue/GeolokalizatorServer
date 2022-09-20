using GeolokalizatorSerwer.Controllers;
using GeolokalizatorSerwer.Entities;
using GeolokalizatorServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GeolokalizatorServer.Controllers
{
    [Route("geolokalizator/time")]
    [ApiController]
    [Authorize]
    public class CollectionTimeController : ControllerBase
    {
        private readonly ICollectionTimeService _timeService;

        public CollectionTimeController(ICollectionTimeService time)
        {
            _timeService = time;
        }

        [HttpGet("year")]
        public ActionResult<IEnumerable<Location>> GetAvailableYears()
        {
            var availableYears = _timeService.GetAvailableYears();

            return Ok(availableYears);
        }

        [HttpGet("month")]
        public ActionResult<IEnumerable<Location>> GetAvailableMonths([FromQuery]int year)
        {
            var availableYears = _timeService.GetAvailableMonths(year);

            return Ok(availableYears);
        }

        [HttpGet("day")]
        public ActionResult<IEnumerable<Location>> GetAvailableDays([FromQuery]int year, [FromQuery]int month)
        {
            var availableYears = _timeService.GetAvailableDays(year,month);

            return Ok(availableYears);
        }

        [HttpGet("hour")]
        public ActionResult<IEnumerable<Location>> GetAvailableHours([FromQuery]int year, [FromQuery]int month, [FromQuery]int day)
        {
            var availableYears = _timeService.GetAvailableHours(year, month, day);

            return Ok(availableYears);
        }

    }
}
