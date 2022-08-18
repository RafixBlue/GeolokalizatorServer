using GeolokalizatorServer.Models;
using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ICollectedDataService
    {
        public List<CollectedDataMapDto> CollectedDataMapHour(int userId, int year, int month, int day, int hour);
        public List<CollectedDataGraphDto> CollectedDataGraphHour(int userId, int year, int month, int day, int hour);
    }
}
