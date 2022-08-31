using GeolokalizatorServer.Models;
using GeolokalizatorServer.Services.Interfaces;
using GeolokalizatorSerwer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Controllers
{
    [Route("geolokalizator/synchronization")]
    [ApiController]
    public class DbSynchronizationController : ControllerBase
    {
        private readonly ISynchronizationService _synchronizationService;

        public DbSynchronizationController(ISynchronizationService synchronizationService)
        {
            _synchronizationService = synchronizationService;
        }

        [HttpGet("get/last")]
        public ActionResult GetLastSynchronizationByUser([FromQuery] int userId)
        {
            var lastSynchronizations = _synchronizationService.GetLastSynchronizationDate(userId);

            return Ok(lastSynchronizations);
        }

        [HttpGet("get/data")]
        public ActionResult GetData([FromQuery] int userId, [FromBody] SynchronizationDateTimeDto dto)
        {

            var lastSynchronizations = _synchronizationService.GetDataForSynchronization(userId, dto);

            return Ok(lastSynchronizations);
        }

        [HttpPost("insert/data")]
        public ActionResult PostData([FromBody] List<SynchronizationDataDto> dto)
        {

            _synchronizationService.InsertCollectedData(dto);

            return Ok();
        }

        [HttpPost("insert/new/device")]
        public ActionResult PostNewDevice([FromBody] List<SynchronizationDataDto> dto)
        {
            _synchronizationService.InsertCollectedData(dto);

            return Ok();
        }

        [HttpGet("get/new/number")]
        public ActionResult GetnewDeviceNumber([FromQuery] int userId)
        {
            var newNumber = _synchronizationService.GetNewDeviceNumber(userId);

            return Ok(newNumber);
        }

        [HttpPatch("update/lastdate")]
        public ActionResult UpdateLastSynchronizationDate([FromBody] SynchronizationDto dto)
        {

            _synchronizationService.UpdateDeviceLastSynchronizationDate(dto);

            return Ok();
        }

        [HttpPost("insert/lastdate")]
        public ActionResult InsertNewDeviceSynchronization([FromBody] SynchronizationDto dto)
        {
            _synchronizationService.InsertNewDeviceSynchronization(dto);

            return Ok();
        }

    }
}
