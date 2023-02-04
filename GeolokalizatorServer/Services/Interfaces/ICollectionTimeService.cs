using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ICollectionTimeService
    {
        public List<string> GetAvailableTimeZones();
        public List<int> GetAvailableYears(string timeZone);
        public List<int> GetAvailableMonths(int year, string timeZone);
        public List<int> GetAvailableDays(int year, int month, string timeZone);
        public List<int> GetAvailableHours(int year, int month, int day, string timeZone);
    }
}
