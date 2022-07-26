using Microsoft.EntityFrameworkCore;
using RestApiBetterRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Route> route { get; set; }
    }
}
