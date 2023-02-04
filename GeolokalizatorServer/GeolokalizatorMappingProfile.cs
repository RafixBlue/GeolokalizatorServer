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
            //CreateMap<User_Data, CollectedDataMapDto>()
            //    .ForMember(m => m.Latitude, c => c.MapFrom(l => l.Location.Latitude))
            //    .ForMember(m => m.Altitude, c => c.MapFrom(l => l.Location.Altitude))
            //    .ForMember(m => m.Longitude, c => c.MapFrom(l => l.Location.Longitude))
            //    .ForMember(m => m.Accuracy, c => c.MapFrom(l => l.Location.Accuracy))
            //    .ForMember(m => m.DateTime, c => c.MapFrom(l => l.Location.DateTime.ToString("HH:mm")))
            //    .ForMember(m => m.TimeZone, c => c.MapFrom(l => l.Location.TimeZone))
            //    .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
            //    .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
            //    .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
            //    .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
            //    .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
            //    .ForMember(m => m.RSSNR, c => c.MapFrom(s => s.Signal.RSSNR));

            //CreateMap<User_Data, CollectedDataGraphDto>()
            //    .ForMember(m => m.DateTime, c => c.MapFrom(l => l.Location.DateTime.Minute.ToString()))
            //    .ForMember(m => m.Accurency, c => c.MapFrom(l => l.Location.Accuracy))
            //    .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
            //    .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
            //    .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
            //    .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
            //    .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
            //    .ForMember(m => m.RSSNR, c => c.MapFrom(s => s.Signal.RSSNR));

            //CreateMap<User_Data, SynchronizationDataDto>()
            //    .ForMember(m => m.UserId, c => c.MapFrom(ud => ud.UserID))
            //    .ForMember(m => m.Latitude, c => c.MapFrom(l => l.Location.Latitude))
            //    .ForMember(m => m.Altitude, c => c.MapFrom(l => l.Location.Altitude))
            //    .ForMember(m => m.Longitude, c => c.MapFrom(l => l.Location.Longitude))
            //    .ForMember(m => m.Accuracy, c => c.MapFrom(l => l.Location.Accuracy))
            //    .ForMember(m => m.DateTime, c => c.MapFrom(l => l.Location.DateTime.ToString()))
            //    .ForMember(m => m.TimeZone, c => c.MapFrom(l => l.Location.TimeZone))
            //    .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
            //    .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
            //    .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
            //    .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
            //    .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
            //    .ForMember(m => m.RSSNR, c => c.MapFrom(s => s.Signal.RSSNR));

            CreateMap<SynchronizationDataDto, User_Data>()
                //.ForPath(m => m.Location.DateTime, c => c.MapFrom(x => DateTime.Parse(x.DateTime)))
                //.ForPath(m => m.Location.TimeZone, c => c.MapFrom(x => x.TimeZone))
                .ForPath(m => m.Location.Latitude, c => c.MapFrom(x => x.Latitude))
                .ForPath(m => m.Location.Altitude, c => c.MapFrom(x => x.Altitude))
                .ForPath(m => m.Location.Longitude, c => c.MapFrom(x => x.Longitude))
                .ForPath(m => m.Location.Accuracy, c => c.MapFrom(x => x.Accuracy))
                .ForPath(m => m.Location.Speed, c => c.MapFrom(x => x.Speed))
                .ForPath(m => m.Location.SpeedAccuracy, c => c.MapFrom(x => x.SpeedAccuracy))

                .ForPath(m => m.Signal.Network_Provider, c => c.MapFrom(x => x.Network_Provider))
                .ForPath(m => m.Signal.Network_Type, c => c.MapFrom(x => x.Network_Type))
                .ForPath(m => m.Signal.Bandwidth, c => c.MapFrom(x => x.Bandwidth))
                .ForPath(m => m.Signal.Earfcn, c => c.MapFrom(x => x.Earfcn))
                .ForPath(m => m.Signal.Tac, c => c.MapFrom(x => x.Tac))
                .ForPath(m => m.Signal.Asu, c => c.MapFrom(x => x.Asu))
                .ForPath(m => m.Signal.Ta, c => c.MapFrom(x => x.Ta))
                .ForPath(m => m.Signal.Rssi, c => c.MapFrom(x => x.Rssi))
                .ForPath(m => m.Signal.Rsrp, c => c.MapFrom(x => x.Rsrp))
                .ForPath(m => m.Signal.Rsrq, c => c.MapFrom(x => x.Rsrq))
                .ForPath(m => m.Signal.Rssnr, c => c.MapFrom(x => x.Rssnr));

            //CreateMap<SynchronizationDto, Synchronization>()
            //    .ForMember(m => m.LastSynchronization, c => c.MapFrom(x => x.NewSynchronizationDate));

            CreateMap<User, AccountInfoDto>();
                
        }
    }
}
