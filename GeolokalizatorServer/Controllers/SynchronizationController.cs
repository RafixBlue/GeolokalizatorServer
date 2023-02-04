using GeolokalizatorServer.Migrations;
using GeolokalizatorServer.Models;
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
    [Route("geolokalizator/synchronization")]
    [ApiController]
    [Authorize]
    public class SynchronizationController : ControllerBase
    {
        private readonly ISynchronizationService _synchronizationService;

        public SynchronizationController(ISynchronizationService synchronizationService)
        {
            _synchronizationService = synchronizationService;
        }

        //[HttpPatch("update/lastdate")]
        //public ActionResult UpdateLastSynchronizationDate([FromBody] SynchronizationDto dto)
        //{

        //    _synchronizationService.UpdateDeviceLastSynchronizationDate(dto);

        //    return Ok();
        //}

        [HttpPost("insert/data")]
        public ActionResult Synchronize([FromBody] List<SynchronizationDataDto> dto)
        {

            _synchronizationService.InsertCollectedData(dto);

            return Ok();
        }

        [HttpGet("get/last-synchronization")]
        public ActionResult GetLastSynchronization()
        {
            var lastSynchronization = _synchronizationService.GetLastSynchronizationDate();

            return Ok(lastSynchronization);
        }

    }
}
