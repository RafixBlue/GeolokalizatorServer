﻿using GeolokalizatorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ISynchronizationService
    {
        public List<SynchronizationDateTimeDto> GetLastSynchronizationDate(int userId);
        public List<SynchronizationDataDto> GetDataForSynchronization(int userId, SynchronizationDateTimeDto synchronizationDto);
        public void InsertCollectedData(List<SynchronizationDataDto> dto);
        public int? GetNewDeviceNumber(int userId);
        public void UpdateDeviceLastSynchronizationDate(SynchronizationDto dto);
        public void InsertNewDeviceSynchronization(SynchronizationDto dto);
    }
}
