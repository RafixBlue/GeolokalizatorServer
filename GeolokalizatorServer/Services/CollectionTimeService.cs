using GeolokalizatorServer.Exceptions;
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

        //private List<int> GetLocationIdListByUser(int? userId)
        //{
        //    var userDatas = _dbContext.UserDatas.Where(u => u.UserID == userId).ToList();
        //    var locationIDs = userDatas.Select(l => l.LocationID).ToList();

        //    if (locationIDs.Count <= 0) throw new NotFoundException("This user has no location data");

        //    return locationIDs;
        //}

        public List<string> GetAvailableTimeZones()
        {
            var userId = _userContextService.GetUserId;

            var availableTimeZones = _dbContext.UserDatas
                .Where(ud => ud.UserID == userId)
                .OrderBy(x => x.TimeZone)
                .Select(x => x.TimeZone)
                .Distinct()
                .ToList();

            return availableTimeZones;
        }

        public List<int> GetAvailableYears(string timeZone)
        {

            var userId = _userContextService.GetUserId;

            var availableYears = _dbContext.UserDatas
                .Where(ud => ud.UserID == userId)
                .Where(ud => ud.TimeZone == timeZone)
                .OrderBy(dt => dt.MeasurementTime)
                .Select(dt => dt.MeasurementTime.Year)
                .Distinct()
                .ToList();

            return availableYears;
        }

        public List<int> GetAvailableMonths(int year, string timeZone)
        {
            var userId = _userContextService.GetUserId;

            var availableMonth = _dbContext.UserDatas
                .Where(ud => ud.UserID == userId)
                .Where(ud => ud.TimeZone == timeZone)
                .Where(ud => ud.MeasurementTime.Year == year)
                .OrderBy(o => o.MeasurementTime)
                .Select(ud => ud.MeasurementTime.Month)
                .Distinct()
                .ToList();

            return availableMonth;
        }
        public List<int> GetAvailableDays(int year, int month, string timeZone)
        {
            var userId = _userContextService.GetUserId;

            var availableDay = _dbContext.UserDatas
                .Where(ud => ud.UserID == userId)
                .Where(ud => ud.TimeZone == timeZone)
                .Where(ud => ud.MeasurementTime.Year == year)
                .Where(ud => ud.MeasurementTime.Month == month)
                .OrderBy(o => o.MeasurementTime)
                .Select(ud => ud.MeasurementTime.Day)
                .Distinct()
                .ToList();

            return availableDay;
        }

        public List<int> GetAvailableHours(int year, int month, int day, string timeZone)
        {
            var userId = _userContextService.GetUserId;

            var availableHour = _dbContext.UserDatas
                .Where(ud => ud.UserID == userId)
                .Where(ud => ud.TimeZone == timeZone)
                .Where(ud => ud.MeasurementTime.Year == year)
                .Where(ud => ud.MeasurementTime.Month == month)
                .Where(ud => ud.MeasurementTime.Day == day)
                .OrderBy(o => o.MeasurementTime)
                .Select(dt => dt.MeasurementTime.Hour)
                .Distinct()
                .ToList();

            return availableHour;
        }

    }
}
