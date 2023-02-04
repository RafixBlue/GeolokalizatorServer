using GeolokalizatorServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using GeolokalizatorServer.Services.Interfaces;

namespace GeolokalizatorServer.Controllers
{
    [Route("geolokalizator/temp")]
    [ApiController]
    [Authorize]
    public class TempControler : ControllerBase
    {
        private readonly ISynchronizationService _synchronizationService;

        public TempControler(ISynchronizationService synchronizationService)
        {
            _synchronizationService = synchronizationService;
        }

        //[HttpPost("insert/lastdate")]
        //public ActionResult InsertNewDeviceSynchronization([FromBody] SynchronizationDto dto)
        //{
        //    _synchronizationService.InsertNewDeviceSynchronization(dto);

        //    return Ok();
        //}

        //[HttpPost("insert/timezone")]
        //public ActionResult PostTimeZone([FromBody] List<String> dto)
        //{
        //    _synchronizationService.AddMissingTimeZones(dto);

        //    return Ok();
        //}


        

        /*[HttpGet("get/data")]
        public ActionResult GetData([FromQuery] int userId, [FromBody] SynchronizationDateTimeDto dto)
        {

            var lastSynchronizations = _synchronizationService.GetDataForSynchronization(userId, dto);

            return Ok(lastSynchronizations);
        }*/



        
    }
}
