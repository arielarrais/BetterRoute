using AutoMapper;
using RestApiBetterRoute.Application.Dtos;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Application.Mappers
{
    public class ModelToDtoMappingRoute : Profile
    {
        public ModelToDtoMappingRoute()
        {
            RouteDtoMap();
        }

        private void RouteDtoMap()
        {
            CreateMap<Route, RouteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(x => x.Origin))
                .ForMember(dest => dest.Destiny, opt => opt.MapFrom(x => x.Destiny))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }


}
