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

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.UserDatas.Any())
                {
                    var usersData = GetUserData();
                    _dbContext.UserDatas.AddRange(usersData);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "TestUser",
                    Email = "testuser@test.com",
                    PasswordHash = "hashHere",
                    Role = new Role()
                    {
                        Name = "User"
                    }
                },
                new User()
                {
                    Name = "TestManager",
                    Email = "testManager@test.com",
                    PasswordHash = "hashHere",
                    Role = new Role()
                    {
                        Name = "Manager"
                    }
                },
                new User()
                {
                    Name = "TestAdmin",
                    Email = "testAdmin@test.com",
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
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 1, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 2, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 3, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 4, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 5, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 6, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 8, 7, 0),
                        Accuracy ="10"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 2, 8, 8, 0),
                        Accuracy ="234"
                    }
                },
                new User_Data()
                {
                    UserID = 1,
                    Signal = new Signal()
                    {
                        Network_Provider = "Test Mobile",
                        Network_Type = "LTE",
                        RSSI = "234",
                        RSRP = "234",
                        RSRQ = "234",
                        RSSNR = "234",
                    },
                    Location = new Location()
                    {
                        Latitude = "1",
                        Altitude = "1",
                        Longitude="1",
                        DateTime= new DateTime(2008, 3, 1, 7, 9, 0),
                        Accuracy ="234"
                    }
                }
            };

            return usersData;
        }
    }
}
