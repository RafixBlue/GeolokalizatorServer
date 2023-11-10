using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ICollectionTimeService
    {
        public List<string> GetAvailableTimeZones(string user);
        public List<string> GetAvailablePlace(string user);
        public List<string> GetAvailableStartTime(string place, string user);
        public List<int> GetAvailableYears(string timeZone, string user);
        public List<string> GetAvailableDescription1(string place,string startTime, string user);
        public List<string> GetAvailableDescription2(string place, string startTime, string user);
        public List<string> GetAvailableDescription3(string place, string startTime, string user);
        public List<int> GetAvailableMonths(int year, string timeZone, string user);
        public List<int> GetAvailableDays(int year, int month, string timeZone, string user);
        public List<int> GetAvailableHours(int year, int month, int day, string timeZone, string user);
    }
}
