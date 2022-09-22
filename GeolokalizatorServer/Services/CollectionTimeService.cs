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
        private readonly IUserContextService _userContextService;

        public CollectionTimeService(GeolokalizatorDbContext dbContext, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
        }

        private List<int> GetLocationIdListByUser(int? userId)
        {
            var userDatas = _dbContext.UserDatas.Where(u => u.UserID == userId).ToList();
            var locationIDs = userDatas.Select(l => l.LocationID).ToList();
            return locationIDs;
        }

        public List<string> GetAvailableTimeZones()
        {

            //var userId = _userContextService.GetUserId;

            var locationIDs = GetLocationIdListByUser(1);

            var availableTimeZones = _dbContext.Locations
                .Where(x => locationIDs.Contains(x.ID))
                .OrderBy(x => x.TimeZone)
                .Select(x => x.TimeZone)
                .Distinct()
                .ToList();

            return availableTimeZones;

        }

        public List<int> GetAvailableYears()
        {

            var userId = _userContextService.GetUserId;

            var locationIDs = GetLocationIdListByUser(userId);

            var availableYears = _dbContext.Locations
                .Where(x => locationIDs.Contains(x.ID))
                .OrderBy(dt => dt.DateTime)
                .Select(dt => dt.DateTime.Year)
                .Distinct()
                .ToList();

            return availableYears;
            
        }

        public List<int> GetAvailableMonths(int year)
        {
            var userId = _userContextService.GetUserId;

            var locationIDs = GetLocationIdListByUser(userId);

            var availableMonth = _dbContext.Locations
                .Where(l => locationIDs.Contains(l.ID) && (l.DateTime.Year == year))
                .OrderBy(x => x.DateTime)
                .Select(dt => dt.DateTime.Month)
                .Distinct()
                .ToList();

            return availableMonth;

        }
        public List<int> GetAvailableDays(int year, int month)
        {
            var userId = _userContextService.GetUserId;

            var locationIDs = GetLocationIdListByUser(userId);

            var availableDay = _dbContext.Locations
                .Where(l => locationIDs.Contains(l.ID) && (l.DateTime.Year == year) && (l.DateTime.Month == month))
                .OrderBy(x => x.DateTime)
                .Select(dt => dt.DateTime.Day)
                .Distinct()
                .ToList();

            return availableDay;

        }

        public List<int> GetAvailableHours(int year,int month, int day)
        {
            var userId = _userContextService.GetUserId;

            var locationIDs = GetLocationIdListByUser(userId);

            var availableHour = _dbContext.Locations
                .Where(l => locationIDs.Contains(l.ID) && (l.DateTime.Year == year) && (l.DateTime.Month == month) && (l.DateTime.Day == day))
                .OrderBy(x => x.DateTime)
                .Select(dt => dt.DateTime.Hour)
                .Distinct()
                .ToList();

            return availableHour;

        }

    }
}
