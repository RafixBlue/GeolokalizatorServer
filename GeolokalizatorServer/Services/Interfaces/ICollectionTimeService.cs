using GeolokalizatorSerwer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface ICollectionTimeService
    {
        public List<int> GetAvailableYears(int userId);
        public List<int> GetAvailableMonths(int userId, int year);
        public List<int> GetAvailableDays(int userId, int year, int month);
        public List<int> GetAvailableHours(int userId, int year, int month, int day);
    }
}
