using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ICollectionTimeService
    {
        public List<int> GetAvailableYears();
        public List<int> GetAvailableMonths(int year);
        public List<int> GetAvailableDays(int year, int month);
        public List<int> GetAvailableHours(int year, int month, int day);
    }
}
