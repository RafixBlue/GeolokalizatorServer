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
        public ActionResult<IEnumerable<Location>> GetAvailableTimeZones([FromQuery] string user)
        {
            var availableTimezones = _timeService.GetAvailableTimeZones(user);

            return Ok(availableTimezones);
        }
        [HttpGet("place")]
        public ActionResult<IEnumerable<string>> GetAvailablePlace([FromQuery] string user)
        {
            var availablePlaces = _timeService.GetAvailablePlace(user);

            return Ok(availablePlaces);
        }

        [HttpGet("year")]
        public ActionResult<IEnumerable<Location>> GetAvailableYears([FromQuery] string timeZone, [FromQuery] string user)
        {
            var availableYears = _timeService.GetAvailableYears(timeZone, user);

            return Ok(availableYears);
        }

        [HttpGet("start")]
        public ActionResult<IEnumerable<string>> GetAvailableStartTime([FromQuery] string place, [FromQuery] string user)
        {
            var availableStartTime = _timeService.GetAvailableStartTime(place, user);

            return Ok(availableStartTime);
        }

        [HttpGet("month")]
        public ActionResult<IEnumerable<Location>> GetAvailableMonths([FromQuery] int year, [FromQuery] string timeZone, [FromQuery] string user)
        {
            var availableYears = _timeService.GetAvailableMonths(year, timeZone, user);

            return Ok(availableYears);
        }

        [HttpGet("des1")]
        public ActionResult<IEnumerable<string>> GetAvailableDescription1([FromQuery] string place, [FromQuery] string startTime, [FromQuery] string user)
        {
            var availableDescription1 = _timeService.GetAvailableDescription1(place, startTime, user);

            return Ok(availableDescription1);
        }

        [HttpGet("des2")]
        public ActionResult<IEnumerable<string>> GetAvailableDescription2([FromQuery] string place, [FromQuery] string startTime, [FromQuery] string user)
        {
            var availableDescription2 = _timeService.GetAvailableDescription2(place, startTime, user);

            return Ok(availableDescription2);
        }

        [HttpGet("des3")]
        public ActionResult<IEnumerable<string>> GetAvailableDescription3([FromQuery] string place, [FromQuery] string startTime, [FromQuery] string user)
        {
            var availableDescription3 = _timeService.GetAvailableDescription3(place, startTime, user);

            return Ok(availableDescription3);
        }

        [HttpGet("day")]
        public ActionResult<IEnumerable<Location>> GetAvailableDays([FromQuery] int year, [FromQuery] int month, [FromQuery] string timeZone, [FromQuery] string user)
        {
            var availableYears = _timeService.GetAvailableDays(year, month, timeZone, user);

            return Ok(availableYears);
        }

        [HttpGet("hour")]
        public ActionResult<IEnumerable<Location>> GetAvailableHours([FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] string timeZone, [FromQuery] string user)
        {
            var availableYears = _timeService.GetAvailableHours(year, month, day, timeZone, user);

            return Ok(availableYears);
        }

        [HttpGet("place")]
        public ActionResult<IEnumerable<Location>> GetAvailablePlace([FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] string timeZone, [FromQuery] string user)
        {
            var availableYears = _timeService.GetAvailableHours(year, month, day, timeZone, user);

            return Ok(availableYears);
        }

    }
}
