using RestApiBetterRoute.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Application.Interfaces
{
    public interface IApplicationServiceRoute
    {
        void Add(RouteDto routeDto);

        void Update(RouteDto routeDto);

        void Remove(RouteDto routeDto);

        IEnumerable<RouteDto> GetAll();

        string GetBetterRoute(string origin, string destiny);
    }
}
