using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class GeolokalizatorSeeder
    {
        private readonly GeolokalizatorDbContext _dbContext;

        public GeolokalizatorSeeder(GeolokalizatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {

            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                //if (!_dbContext.Users.Any())
                //{
                //    var users = GetUsers();
                //    _dbContext.Users.AddRange(users);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.UserDatas.Any())
                //{
                //    var usersData = GetUserData();
                //    _dbContext.UserDatas.AddRange(usersData);
                //    _dbContext.SaveChanges();
                //}

                //if (!_dbContext.Synchronizations.Any())
                //{
                //    var synchronizations = GetSynchronizations();
                //    _dbContext.Synchronizations.AddRange(synchronizations);
                //    _dbContext.SaveChanges();
                //}
            }
        }

        private IEnumerable<Synchronization> GetSynchronizations()
        {
            var synchronizations = new List<Synchronization>
            {
                new Synchronization()
                {
                    LastSynchronization = new DateTime(2007, 12, 31, 6, 0, 0),
                    TimeZone = "test1",
                    UserID = 1,
                },
                new Synchronization()
                {
                    LastSynchronization = new DateTime(2007, 12, 22, 6, 0, 0),
                    TimeZone = "test1",
                    UserID = 1,
                },
                new Synchronization()
                {
                    LastSynchronization = new DateTime(2007, 12, 31, 6, 0, 0),
                    TimeZone = "test2",
                    UserID = 1,
                },
                new Synchronization()
                {
                    LastSynchronization = new DateTime(2007, 12, 31, 6, 0, 0),
                    TimeZone = "test2",
                    UserID = 1,
                },
            };
            return synchronizations;
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "TestUser",
                    PasswordHash = "hashHere",
                    Role = new Role()
                    {
                        Name = "User"
                    }
                },
                new User()
                {
                    Name = "TestManager",                   
                    PasswordHash = "hashHere",
                    Role = new Role()
                    {
                        Name = "Manager"
                    }
                },
                new User()
                {
                    Name = "TestAdmin",
                    PasswordHash = "hashHere",
                    Role = new Role()
                    {
                        Name = "Admin"
                    }
                }
            };

            return users;
        }

        private IEnumerable<User_Data> GetUserData()
        {
            var usersData = new List<User_Data>()
            {
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",                       
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="10",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    MeasurementTime = new DateTime(2008, 3, 1, 7, 1, 0),
                    TimeZone = "test1",
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        Bandwidth = "254",
                        Earfcn = "288",
                        Tac = "213",
                        Asu = "654",
                        Ta="543",
                        Rssi = "234",
                        Rsrp = "234",
                        Rsrq = "234",
                        Rssnr = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        Accuracy ="234",
                        Speed ="222",
                        SpeedAccuracy="1"
                    }
                }
            };

            return usersData;
        }
    }
}
