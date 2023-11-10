using GeolokalizatorServer.Models;
using GeolokalizatorServer.Models.CollectedDataModels;
using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ICollectedDataService
    {
        public List<CollectedDataDto> CollectedDataHour(int year, int month, int day, int hour, string timezone, string user);
        public List<CollectedDataDto> CollectedDataLabel(string? place,string? startDate, string? description1, string? description2, string? description3,string? user);
    }
}
