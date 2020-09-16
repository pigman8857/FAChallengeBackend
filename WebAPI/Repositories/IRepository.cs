using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WebAPI.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        Task Add(TEntity entity);
        void Remove(TEntity entity);

    }
}
