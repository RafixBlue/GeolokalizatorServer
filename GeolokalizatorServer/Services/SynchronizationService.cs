using AutoMapper;
using GeolokalizatorServer.Migrations;
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

        public List<SynchronizationDateTimeDto> GetLastSynchronizationDate()
        {
            var userId = _userContextService.GetUserId;

            var lastSynchronization = _dbContext.Synchronizations
                .Where(s => s.UserID == userId)
                .GroupBy(s => s.TimeZone)
                .Select(g => new SynchronizationDateTimeDto
                {
                    TimeZone = g.Key,
                    DateTime = g.Max(s => s.LastSynchronization)
                });

            var lastSynchronizations = lastSynchronization.ToList();

            return lastSynchronizations;
        }

        public List<SynchronizationDataDto> GetDataForSynchronization(SynchronizationDateTimeDto synchronizationDto)
        {
            var userId = _userContextService.GetUserId;

            var UserData = _dbContext.UserDatas
               .Include(ud => ud.Signal)
               .Include(ud => ud.Location)
               .Where(ud => ud.UserID == userId && ud.Location.DateTime > synchronizationDto.DateTime && ud.Location.TimeZone == synchronizationDto.TimeZone)
               .OrderBy(ud => ud.Location.DateTime)
               .ToList();

            var SynchronizationData = _mapper.Map<List<SynchronizationDataDto>>(UserData);

            return SynchronizationData;
        }

        public void InsertCollectedData(List<SynchronizationDataDto> dto)
        {
            var SynchronizationData = _mapper.Map<IEnumerable<User_Data>>(dto);

            if (_dbContext.Database.CanConnect())
            {
                _dbContext.UserDatas.AddRange(SynchronizationData);
                _dbContext.SaveChanges();
            }
                
        }

       

        public void UpdateDeviceLastSynchronizationDate(SynchronizationDto dto)
        {
            var synchronizationToUpdate = _dbContext.Synchronizations
                .FirstOrDefault(x => x.UserID == dto.UserId  
                && String.Equals(x.TimeZone, dto.TimeZone));

            //if (synchronizationToUpdate is null) throw new NotFoundException("Synchro not found");

            /*var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, restaurant, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }*/
            
            synchronizationToUpdate.LastSynchronization = dto.NewSynchronizationDate;
            _dbContext.SaveChanges();

        }

        private int getUserIdFromName(string userName)
        {
            var userId = _dbContext.Users
                .Where(u => string.Equals(u.Name, userName))
                .Select(u => u.ID)
                .First();

            return userId;
        }









        public void AddMissingTimeZones(List<string> clientTimeZones)
        {
            var userId = _userContextService.GetUserId;

            var serverTimeZones = _dbContext.Synchronizations
                .Where(s => s.UserID == userId)
                .Select(s => s.TimeZone)
                .ToList();

            var missingTimeZones = clientTimeZones
                .Except(serverTimeZones)
                .ToList();

            var synchronizations = new List<Synchronization>();

            foreach (var timeZone in missingTimeZones)
            {
                synchronizations.Add(new Synchronization
                {
                    UserID = userId.GetValueOrDefault(),
                    TimeZone = timeZone,
                });
            }

            _dbContext.AddRange(synchronizations);
            _dbContext.SaveChanges();

            
        }














        public void InsertNewDeviceSynchronization(SynchronizationDto dto)
        {
            var map = _mapper.Map<Synchronization>(dto);
            _dbContext.Synchronizations.Add(map);
            _dbContext.SaveChanges();

        }

    }
}
