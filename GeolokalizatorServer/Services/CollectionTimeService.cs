using GeolokalizatorServer.Services.Interfaces;
using GeolokalizatorSerwer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services
{
    public class CollectionTimeService : ICollectionTimeService
    {
        private readonly GeolokalizatorDbContext _dbContext;

        public CollectionTimeService(GeolokalizatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private List<int> GetLocationIdListByUser(int userId)
        {
            var userDatas = _dbContext.UserDatas.Where(u => u.UserID == userId).ToList();
            var locationIDs = userDatas.Select(l => l.LocationID).ToList();
            return locationIDs;
        }

        public List<int> GetAvailableYears(int userId)
        {
            var locationIDs = GetLocationIdListByUser(userId);

            var availableYears = _dbContext.Locations
                .Where(x => locationIDs.Contains(x.ID))
                .OrderBy(dt => dt.DateTime)
                .Select(dt => dt.DateTime.Year)
                .Distinct()
                .ToList();

            return availableYears;
            
        }

        public List<int> GetAvailableMonths(int userId,int year)
        {
            var locationIDs = GetLocationIdListByUser(userId);

            var availableMonth = _dbContext.Locations
                .Where(l => locationIDs.Contains(l.ID) && (l.DateTime.Year == year))
                .OrderBy(x => x.DateTime)
                .Select(dt => dt.DateTime.Month)
                .Distinct()
                .ToList();

            return availableMonth;

        }
        public List<int> GetAvailableDays(int userId, int year, int month)
        {
            var locationIDs = GetLocationIdListByUser(userId);

            var availableMonth = _dbContext.Locations
                .Where(l => locationIDs.Contains(l.ID) && (l.DateTime.Year == year) && (l.DateTime.Month == month))
                .OrderBy(x => x.DateTime)
                .Select(dt => dt.DateTime.Day)
                .Distinct()
                .ToList();

            return availableMonth;

        }

        public List<int> GetAvailableHours(int userId, int year,int month, int day)
        {
            var locationIDs = GetLocationIdListByUser(userId);

            var availableMonth = _dbContext.Locations
                .Where(l => locationIDs.Contains(l.ID) && (l.DateTime.Year == year) && (l.DateTime.Month == month) && (l.DateTime.Day == day))
                .OrderBy(x => x.DateTime)
                .Select(dt => dt.DateTime.Hour)
                .Distinct()
                .ToList();

            return availableMonth;

        }
    }
}
