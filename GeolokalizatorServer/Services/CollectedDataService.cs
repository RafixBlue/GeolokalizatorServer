using AutoMapper;
using GeolokalizatorServer.Models;
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

        public List<CollectedDataMapDto> CollectedDataMapHour(int year, int month, int day, int hour)
        {
            var userId = _userContextService.GetUserId;

            var UserData = _dbContext.UserDatas
                .Include(ud => ud.Signal)
                .Include(ud => ud.Location)
                .Where(ud => ud.UserID == userId && ud.Location.DateTime.Year == year && ud.Location.DateTime.Month == month && ud.Location.DateTime.Day == day && ud.Location.DateTime.Hour == hour)
                .OrderBy(ud => ud.Location.DateTime)
                .ToList();

            var UserCollectedData = _mapper.Map<List<CollectedDataMapDto>>(UserData);

            return UserCollectedData;

        }

        public List<CollectedDataGraphDto> CollectedDataGraphHour(int year, int month, int day, int hour)
        {
            var userId = _userContextService.GetUserId;

            var UserData = _dbContext.UserDatas
                .Include(ud => ud.Signal)
                .Include(ud => ud.Location)
                .Where(ud => ud.UserID == userId && ud.Location.DateTime.Year == year && ud.Location.DateTime.Month == month && ud.Location.DateTime.Day == day && ud.Location.DateTime.Hour == hour)
                .OrderBy(ud => ud.Location.DateTime)
                .ToList();

            var UserCollectedData = _mapper.Map<List<CollectedDataGraphDto>>(UserData);

            return UserCollectedData;

        }

        
    }
}
