using GeolokalizatorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ISynchronizationService
    {
        public SynchronizationDateTimeDto GetLastSynchronizationDate();
        //public List<SynchronizationDataDto> GetDataForSynchronization(SynchronizationDateTimeDto synchronizationDto);
        public void InsertCollectedData(List<SynchronizationDataDto> dto);
        //public void UpdateDeviceLastSynchronizationDate(SynchronizationDto dto);
        //public void InsertNewDeviceSynchronization(SynchronizationDto dto);
        //public void AddMissingTimeZones(List<string> clientTimeZones);
    }
}
