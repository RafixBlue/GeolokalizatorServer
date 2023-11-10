using AutoMapper;
using GeolokalizatorServer.Models;
using GeolokalizatorServer.Services.Interfaces;
using GeolokalizatorSerwer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services
{
    public class SynchronizationService : ISynchronizationService
    {
        private readonly GeolokalizatorDbContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public SynchronizationService(GeolokalizatorDbContext dbContext, IUserContextService userContextService, IMapper mapper)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public SynchronizationDateTimeDto GetLastSynchronizationDate()
        {
            var userId = _userContextService.GetUserId;

            var lastSynchronization = _dbContext.Synchronizations
                .Where(s => s.UserID == userId)
                .OrderBy(s => s.LastSynchronization)
                .Select(s => new SynchronizationDateTimeDto
                {
                    TimeZone = s.TimeZone,
                    MeasurementTime = s.LastSynchronization
                })
                .LastOrDefault();

            return lastSynchronization;
        }

        public void InsertCollectedData(List<SynchronizationDataDto> dto)
        {
            var userId = _userContextService.GetUserId;

            foreach(SynchronizationDataDto d in dto)
            {
                d.UserId = (int)userId;
            }

            var synchronizationData = _mapper.Map<IEnumerable<User_Data>>(dto);

            if (_dbContext.Database.CanConnect())
            {
                _dbContext.UserDatas.AddRange(synchronizationData);
                _dbContext.SaveChanges();

                updateSynchronizationDate(dto.Last());
            }
        }

        private void updateSynchronizationDate(SynchronizationDataDto dto)
        {
            var userId = _userContextService.GetUserId;

            var newLastSynchronization = new Synchronization
            {
                UserID = (int)userId,
                TimeZone = dto.TimeZone,
                LastSynchronization = DateTime.Parse(dto.MeasurementTime)
            };

            if (_dbContext.Database.CanConnect())
            {
                _dbContext.Synchronizations.Add(newLastSynchronization);
                _dbContext.SaveChanges();
            }
        }

    }
}
