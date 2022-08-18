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
                .ForMember(m => m.Network_Provider, c => c.MapFrom(s => s.Signal.Network_Provider))
                .ForMember(m => m.Network_Type, c => c.MapFrom(s => s.Signal.Network_Type))
                .ForMember(m => m.RSSI, c => c.MapFrom(s => s.Signal.RSSI))
                .ForMember(m => m.RSRP, c => c.MapFrom(s => s.Signal.RSRP))
                .ForMember(m => m.RSRQ, c => c.MapFrom(s => s.Signal.RSRQ))
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

        }
    }
}
