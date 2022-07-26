using AutoMapper;
using RestApiBetterRoute.Application.Dtos;
using RestApiBetterRoute.Application.Interfaces;
using RestApiBetterRoute.Domain.Core.Interfaces.Services;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiBetterRoute.Application
{
    public class ApplicationServiceRoute : IApplicationServiceRoute
    {
        private readonly IServiceRoute serviceRoute;
        private readonly IMapper mapper;
        public ApplicationServiceRoute(IServiceRoute serviceRoute, IMapper mapper)
        {
            this.serviceRoute = serviceRoute;
            this.mapper = mapper;
        }
        public void Add(RouteDto routeDto)
        {
            var route = mapper.Map<Route>(routeDto);
            serviceRoute.Add(route);
        }

        public void Remove(RouteDto routeDto)
        {
            var route = mapper.Map<Route>(routeDto);
            serviceRoute.Remove(route);
        }

        public void Update(RouteDto routeDto)
        {
            var route = mapper.Map<Route>(routeDto);
            serviceRoute.Update(route);
        }

        public IEnumerable<RouteDto> GetAll()
        {
            var routes = serviceRoute.GetAll();
            var routesDto = mapper.Map<IEnumerable<RouteDto>>(routes);

            return routesDto;
        }

        public string GetBetterRoute(string orig, string dest)
        {
            var routes = serviceRoute.GetBetterRoute(orig, dest);

            return routes;
        }
    }
}
