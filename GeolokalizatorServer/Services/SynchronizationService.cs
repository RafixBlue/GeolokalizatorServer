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
        private readonly IMapper _mapper;

        public SynchronizationService(GeolokalizatorDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
    }

        public List<SynchronizationDateTimeDto> GetLastSynchronizationDate(int userId)
        {
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

        public List<SynchronizationDataDto> GetDataForSynchronization(int userId, SynchronizationDateTimeDto synchronizationDto)
        {
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

        public int? GetNewDeviceNumber(int userId)
        {
            var maxDeviceNumber = _dbContext.Synchronizations.Where(x => x.UserID == userId)
                .Max(x => (int?)x.DeviceNumber);

            var newDeviceNumber = maxDeviceNumber + 1;

            if (maxDeviceNumber is null)
            {
                newDeviceNumber = 1;
            }

            return newDeviceNumber;
        }

        public void UpdateDeviceLastSynchronizationDate(SynchronizationDto dto)
        {
            var synchronizationToUpdate = _dbContext
                .Synchronizations
                .FirstOrDefault(x => x.UserID == dto.UserId && x.DeviceNumber == dto.DeviceNumber && String.Equals(x.TimeZone, dto.TimeZone));

            //if (synchronizationToUpdate is null) throw new NotFoundException("Synchro not found");

            /*var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, restaurant, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }*/
            
            synchronizationToUpdate.LastSynchronization = dto.NewSynchronizationDate;
            _dbContext.SaveChanges();

        }

        public void InsertNewDeviceSynchronization(SynchronizationDto dto)
        {
            var test = _mapper.Map<Synchronization>(dto);
            _dbContext.Synchronizations.Add(test);
            _dbContext.SaveChanges();

        }

    }
}
