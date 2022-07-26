using RestApiBetterRoute.Domain.Core.Interfaces.Repositories;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Infrastructure.Data.Repositories
{
    public class RepositoryRoute : RepositoryBase<Route>, IRepositoryRoute
    {
        private readonly SqlContext sqlContext;

        public RepositoryRoute(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
