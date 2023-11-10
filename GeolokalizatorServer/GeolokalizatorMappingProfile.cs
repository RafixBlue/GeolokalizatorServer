using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeolokalizatorServer.Models;
using GeolokalizatorServer.Models.CollectedDataModels;
using GeolokalizatorSerwer.Entities;

namespace GeolokalizatorServer
{
    public class GeolokalizatorMappingProfile : Profile
    {
        public GeolokalizatorMappingProfile()
        {

            CreateMap<SynchronizationDataDto, User_Data>()             
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
                .ForPath(m => m.Signal.Rssnr, c => c.MapFrom(x => x.Rssnr))

                .ForPath(m => m.Label.Place, c => c.MapFrom(x => x.Place))
                .ForPath(m => m.Label.StartDate, c => c.MapFrom(x => x.StartDate))
                .ForPath(m => m.Label.Description1, c => c.MapFrom(x => x.Description1))
                .ForPath(m => m.Label.Description2, c => c.MapFrom(x => x.Description2))
                .ForPath(m => m.Label.Description3, c => c.MapFrom(x => x.Description3));

            CreateMap<User_Data, CollectedDataDto>()               
                .ForMember(m => m.MeasurementTime, c => c.MapFrom(x => x.MeasurementTime.Hour))
                .ForPath(m => m.Latitude, c => c.MapFrom(x => x.Location.Latitude))
                .ForPath(m => m.Altitude, c => c.MapFrom(x => x.Location.Altitude))
                .ForPath(m => m.Longitude, c => c.MapFrom(x => x.Location.Longitude))
                .ForPath(m => m.Accuracy, c => c.MapFrom(x => x.Location.Accuracy))
                .ForPath(m => m.Speed, c => c.MapFrom(x => x.Location.Speed))
                .ForPath(m => m.SpeedAccuracy, c => c.MapFrom(x => x.Location.SpeedAccuracy))

                .ForPath(m => m.Network_Provider, c => c.MapFrom(x => x.Signal.Network_Provider))
                .ForPath(m => m.Network_Type, c => c.MapFrom(x => x.Signal.Network_Type))
                .ForPath(m => m.Bandwidth, c => c.MapFrom(x => x.Signal.Bandwidth))
                .ForPath(m => m.Earfcn, c => c.MapFrom(x => x.Signal.Earfcn))
                .ForPath(m => m.Tac, c => c.MapFrom(x => x.Signal.Tac))
                .ForPath(m => m.Asu, c => c.MapFrom(x => x.Signal.Asu))
                .ForPath(m => m.Ta, c => c.MapFrom(x => x.Signal.Ta))
                .ForPath(m => m.Rssi, c => c.MapFrom(x => x.Signal.Rssi))
                .ForPath(m => m.Rsrp, c => c.MapFrom(x => x.Signal.Rsrp))
                .ForPath(m => m.Rsrq, c => c.MapFrom(x => x.Signal.Rsrq))
                .ForPath(m => m.Rssnr, c => c.MapFrom(x => x.Signal.Rssnr))

                .ForPath(m => m.Place, c => c.MapFrom(x => x.Label.Place))
                .ForPath(m => m.StartDate, c => c.MapFrom(x => x.Label.StartDate))
                .ForPath(m => m.Description1, c => c.MapFrom(x => x.Label.Description1))
                .ForPath(m => m.Description2, c => c.MapFrom(x => x.Label.Description2))
                .ForPath(m => m.Description3, c => c.MapFrom(x => x.Label.Description3));
            //CreateMap<SynchronizationDto, Synchronization>()
            //    .ForMember(m => m.LastSynchronization, c => c.MapFrom(x => x.NewSynchronizationDate));

            CreateMap<User, AccountInfoDto>();
                
        }
    }
}
