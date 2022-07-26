using AutoMapper;
using RestApiBetterRoute.Application.Dtos;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Application.Mappers
{
    public class DtoToModelMappingRoute : Profile
    {
        public DtoToModelMappingRoute()
        {
            RouteMap();
        }
        private void RouteMap()
        {
            CreateMap<RouteDto, Route>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(x => x.Origin))
                .ForMember(dest => dest.Destiny, opt => opt.MapFrom(x => x.Destiny))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));

        }
    }
}
