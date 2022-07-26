using RestApiBetterRoute.Domain.Core.Interfaces.Repositories;
using RestApiBetterRoute.Domain.Core.Interfaces.Services;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Domain.Services
{
    public class ServiceRoute : ServiceBase<Route>, IServiceRoute
    {
        private readonly IRepositoryRoute repositoryRoute;

        public ServiceRoute(IRepositoryRoute repositoryRoute) : base(repositoryRoute)
        {
            this.repositoryRoute = repositoryRoute;
        }
    }
}
