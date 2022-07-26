using AutoMapper;
using RestApiBetterRoute.Application.Dtos;
using RestApiBetterRoute.Domain.Core.Interfaces.Repositories;
using RestApiBetterRoute.Domain.Core.Interfaces.Services;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiBetterRoute.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        void IServiceBase<TEntity>.Add(TEntity obj)
        {
            repository.Add(obj);
        }

        void IServiceBase<TEntity>.Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        void IServiceBase<TEntity>.Update(TEntity obj)
        {
            repository.Update(obj);
        }
        IEnumerable<TEntity> IServiceBase<TEntity>.GetAll()
        {
            return repository.GetAll();
        }

        string IServiceBase<TEntity>.GetBetterRoute(string orig, string dest)
        {
            List<Route> routes = (List<Route>)repository.GetAll();

            List<Route> findRouteOrigin = new List<Route>();
            List<Route> routeFounded = new List<Route>();
            List<Route> connectionRoutes = new List<Route>();

            string origin = orig.ToUpper();
            string destiny = dest.ToUpper();

            if (routes.Exists(x => x.Origin.ToUpper() == origin || x.Destiny.ToUpper() == destiny))
            {
                foreach (Route searchOrigin in routes)
                {
                    if (searchOrigin.Origin == origin)
                    {
                        findRouteOrigin.Add(searchOrigin);
                    };
                }

                foreach (Route connectRoute in findRouteOrigin)
                {
                    connectionRoutes.Add(connectRoute);

                    while (!connectionRoutes.Last().Destiny.ToUpper().Equals(destiny))
                    {
                        foreach (Route nextRoute in routes)
                        {
                            if (connectionRoutes.Last().Destiny.ToUpper() == nextRoute.Origin.ToUpper())
                            {
                                connectionRoutes.Add(nextRoute);
                                break;
                            };
                        }
                    }

                    if (connectionRoutes.Last().Destiny.ToUpper().Equals(destiny.ToUpper()))
                    {
                        string allRoute = string.Empty;
                        decimal valueRoute = 0;
                        foreach (Route routeOrigin in connectionRoutes)
                        {
                            allRoute += routeOrigin.Origin + "-";
                            valueRoute += routeOrigin.Value;
                        }

                        allRoute += destiny;

                        routeFounded.Add(new Route
                        {
                            Origin = origin + "-" + destiny,
                            Destiny = allRoute,
                            Value = valueRoute
                        });

                        connectionRoutes.Clear();
                    }
                }

                var betterRoute = routeFounded.GroupBy(r => r.Destiny)
                .Select(min => new
                {
                    Destiny = min.Key,
                    Value = min.Min(m => m.Value)
                }).FirstOrDefault();

                return betterRoute.Destiny + " ao custo " + betterRoute.Value;
            }
            else if (routes.Exists(x => x.Origin == origin))
            {
                return "Rota de origem nao encontrada";
            }
            else if (routes.Exists(x => x.Destiny == destiny))
            {
                return "Rota de destino nao encontrada";
            }

            return "Rota nao encontrada";
        }
    }
}
