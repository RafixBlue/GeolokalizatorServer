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

        public List<string> GetAvailableTimeZones(string user)
        {
            var userId = _userContextService.GetUserId;          

            var availableTimeZones = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .OrderBy(x => x.TimeZone)
                .Select(x => x.TimeZone)
                .Distinct()
                .ToList();

            return availableTimeZones;
        }

        public List<int> GetAvailableYears(string timeZone, string user)
        {

            var userId = _userContextService.GetUserId;

            var availableYears = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.TimeZone == timeZone)
                .OrderBy(dt => dt.MeasurementTime)
                .Select(dt => dt.MeasurementTime.Year)
                .Distinct()
                .ToList();

            return availableYears;
        }

        public List<int> GetAvailableMonths(int year, string timeZone, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableMonth = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.TimeZone == timeZone)
                .Where(ud => ud.MeasurementTime.Year == year)
                .OrderBy(o => o.MeasurementTime)
                .Select(ud => ud.MeasurementTime.Month)
                .Distinct()
                .ToList();

            return availableMonth;
        }
        public List<int> GetAvailableDays(int year, int month, string timeZone, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableDay = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.TimeZone == timeZone)
                .Where(ud => ud.MeasurementTime.Year == year)
                .Where(ud => ud.MeasurementTime.Month == month)
                .OrderBy(o => o.MeasurementTime)
                .Select(ud => ud.MeasurementTime.Day)
                .Distinct()
                .ToList();

            return availableDay;
        }

        public List<int> GetAvailableHours(int year, int month, int day, string timeZone, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableHour = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
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

        public List<string> GetAvailablePlace(string user)
        {
            var userId = _userContextService.GetUserId;          

            var availablePlaces = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .OrderBy(x => x.Label.Place)
                .Select(x => x.Label.Place)
                .Distinct()
                .ToList();

            return availablePlaces;
        }

        public List<string> GetAvailableStartTime(string place, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableStartTimes = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.Label.Place == place)
                .OrderBy(x => x.Label.StartDate)
                .Select(x => x.Label.StartDate)
                .Distinct()
                .ToList();

            return availableStartTimes;
        }

        public List<string> GetAvailableDescription1(string place, string startTime, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableDescription1 = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.Label.Place == place)
                .Where(ud => ud.Label.StartDate == startTime)
                .OrderBy(x => x.Label.Description1)
                .Select(x => x.Label.Description1)
                .Distinct()
                .ToList();

            return availableDescription1;
        }

        public List<string> GetAvailableDescription2(string place, string startTime, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableDescription2 = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.Label.Place == place)
                .Where(ud => ud.Label.StartDate == startTime)
                .OrderBy(x => x.Label.Description2)
                .Select(x => x.Label.Description2)
                .Distinct()
                .ToList();

            return availableDescription2;
        }

        public List<string> GetAvailableDescription3(string place, string startTime, string user)
        {
            var userId = _userContextService.GetUserId;

            var availableDescription3 = _dbContext.UserDatas
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => ud.Label.Place == place)
                .Where(ud => ud.Label.StartDate == startTime)
                .OrderBy(x => x.Label.Description3)
                .Select(x => x.Label.Description3)
                .Distinct()
                .ToList();

            return availableDescription3;
        }
    }
}
