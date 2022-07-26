using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiBetterRoute.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IEnumerable<TEntity> GetAll();

        string GetBetterRoute(string orig, string dest);
    }
}
