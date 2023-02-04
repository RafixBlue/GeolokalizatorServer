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

        [HttpGet("timezone")]
        public ActionResult<IEnumerable<Location>> GetAvailableTimeZones()
        {
            var availableTimezones = _timeService.GetAvailableTimeZones();

            return Ok(availableTimezones);
        }

        [HttpGet("year")]
        public ActionResult<IEnumerable<Location>> GetAvailableYears([FromQuery] string timeZone)
        {
            var availableYears = _timeService.GetAvailableYears(timeZone);

            return Ok(availableYears);
        }

        [HttpGet("month")]
        public ActionResult<IEnumerable<Location>> GetAvailableMonths([FromQuery] int year, [FromQuery] string timeZone)
        {
            var availableYears = _timeService.GetAvailableMonths(year, timeZone);

            return Ok(availableYears);
        }

        [HttpGet("day")]
        public ActionResult<IEnumerable<Location>> GetAvailableDays([FromQuery] int year, [FromQuery] int month, [FromQuery] string timeZone)
        {
            var availableYears = _timeService.GetAvailableDays(year, month, timeZone);

            return Ok(availableYears);
        }

        [HttpGet("hour")]
        public ActionResult<IEnumerable<Location>> GetAvailableHours([FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] string timeZone)
        {
            var availableYears = _timeService.GetAvailableHours(year, month, day, timeZone);

            return Ok(availableYears);
        }

    }
}
