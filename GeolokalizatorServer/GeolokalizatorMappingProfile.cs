using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeolokalizatorServer.Models;
using GeolokalizatorSerwer.Entities;

namespace GeolokalizatorServer
{
    public class GeolokalizatorMappingProfile : Profile
    {
        public GeolokalizatorMappingProfile()
        {
            CreateMap<User_Data, CollectedDataMapDto>()
                .ForMember(m => m.Latitude, c => c.MapFrom(l => l.Location.Latitude))
                .ForMember(m => m.Altitude, c => c.MapFrom(l => l.Location.Altitude))
                .ForMember(m => m.Longitude, c => c.MapFrom(l => l.Location.Longitude))
                .ForMember(m => m.Accuracy, c => c.MapFrom(l => l.Location.Accuracy))
                .ForMember(m => m.DateTime, c => c.MapFrom(l => l.Location.DateTime.ToString("HH:mm")))
                .ForMember(m => m.TimeZone, c => c.MapFrom(l => l.Location.TimeZone))
                .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
                .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
                .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
                .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
                .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
                .ForMember(m => m.RSSNR, c => c.MapFrom(s => s.Signal.RSSNR));

            CreateMap<User_Data, CollectedDataGraphDto>()
                .ForMember(m => m.DateTime, c => c.MapFrom(l => l.Location.DateTime.Minute.ToString()))
                .ForMember(m => m.Accurency, c => c.MapFrom(l => l.Location.Accuracy))
                .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
                .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
                .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
                .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
                .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
                .ForMember(m => m.RSSNR, c => c.MapFrom(s => s.Signal.RSSNR));

            CreateMap<User_Data, SynchronizationDataDto>()
                .ForMember(m=> m.UserId,c => c.MapFrom(ud => ud.UserID))
                .ForMember(m => m.Latitude, c => c.MapFrom(l => l.Location.Latitude))
                .ForMember(m => m.Altitude, c => c.MapFrom(l => l.Location.Altitude))
                .ForMember(m => m.Longitude, c => c.MapFrom(l => l.Location.Longitude))
                .ForMember(m => m.Accuracy, c => c.MapFrom(l => l.Location.Accuracy))
                .ForMember(m => m.DateTime, c => c.MapFrom(l => l.Location.DateTime.ToString()))
                .ForMember(m => m.TimeZone, c => c.MapFrom(l => l.Location.TimeZone))
                .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
                .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
                .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
                .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
                .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
                .ForMember(m => m.RSSNR, c => c.MapFrom(s => s.Signal.RSSNR));

            CreateMap<SynchronizationDataDto, User_Data>()
                .ForPath(m => m.Location.Latitude, c => c.MapFrom(x => x.Latitude))
                .ForPath(m => m.Location.Altitude, c => c.MapFrom(x => x.Altitude))
                .ForPath(m => m.Location.Longitude, c => c.MapFrom(x => x.Longitude))
                .ForPath(m => m.Location.Accuracy, c => c.MapFrom(x => x.Accuracy))
                .ForPath(m => m.Location.DateTime, c => c.MapFrom(x => DateTime.Parse(x.DateTime)))
                .ForPath(m => m.Location.TimeZone, c => c.MapFrom(x => x.TimeZone))
                .ForPath(m => m.Signal.Network_Provider, c => c.MapFrom(x => x.Network_Provider))
                .ForPath(m => m.Signal.Network_Type, c => c.MapFrom(x => x.Network_Type))
                .ForPath(m => m.Signal.RSSI, c => c.MapFrom(x => x.RSSI))
                .ForPath(m => m.Signal.RSRP, c => c.MapFrom(x => x.RSRP))
                .ForPath(m => m.Signal.RSRQ, c => c.MapFrom(x => x.RSRQ))
                .ForPath(m => m.Signal.RSSNR, c => c.MapFrom(x => x.RSSNR));

            CreateMap<SynchronizationDto, Synchronization>()
                .ForMember(m => m.LastSynchronization, c => c.MapFrom(x => x.NewSynchronizationDate));

            CreateMap<User, AccountInfoDto>();
                
        }
    }
}
