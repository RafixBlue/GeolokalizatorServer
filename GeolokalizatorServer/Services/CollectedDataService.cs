using AutoMapper;
using GeolokalizatorServer.Exceptions;
using GeolokalizatorServer.Models;
using GeolokalizatorServer.Models.CollectedDataModels;
using GeolokalizatorServer.Services.Interfaces;
using GeolokalizatorSerwer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services
{
    public class CollectedDataService : ICollectedDataService
    {
        private readonly GeolokalizatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public CollectedDataService(GeolokalizatorDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public List<CollectedDataDto> CollectedDataHour(int year, int month, int day, int hour,string timezone, string user)
        {
            var userId = _userContextService.GetUserId;

            var userData = _dbContext.UserDatas
                .Include(ud => ud.Signal)
                .Include(ud => ud.Location)
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud =>  ud.MeasurementTime.Year == year && ud.MeasurementTime.Month == month && ud.MeasurementTime.Day == day && ud.MeasurementTime.Hour == hour && ud.TimeZone == timezone)
                .OrderBy(ud => ud.MeasurementTime)
                .ToList();
            
            if (userData.Count <= 0) { throw new NotFoundException("Data not found for this parameters"); }

            var userCollectedData = _mapper.Map<IEnumerable<CollectedDataDto>>(userData);

            return userCollectedData.ToList();

        }

        public List<CollectedDataDto> CollectedDataLabel(string? place, string? startDate, string? description1, string? description2, string? description3, string user)
        {
            var userId = _userContextService.GetUserId;

            var userData = _dbContext.UserDatas
                .Include(ud => ud.Signal)
                .Include(ud => ud.Location)
                .Include(ud => ud.Label)
                .Where(ud => (ud.UserID == userId && user == "") || ud.User.Name == user)
                .Where(ud => 
                   (ud.Label.Place == place)
                && (ud.Label.StartDate == startDate || ud.Label.StartDate == "")
                && (ud.Label.Description1 == description1 || ud.Label.Description1 == "")
                && (ud.Label.Description2 == description2 || ud.Label.Description2 == "")
                && (ud.Label.Description2 == description3 || ud.Label.Description3 == ""))
                .OrderBy(ud => ud.MeasurementTime)
                .ToList();

            if (userData.Count <= 0) { throw new NotFoundException("Data not found for this parameters"); }

            var userCollectedData = _mapper.Map<IEnumerable<CollectedDataDto>>(userData);

            return userCollectedData.ToList();

        }

    }
}
