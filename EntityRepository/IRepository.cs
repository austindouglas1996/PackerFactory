using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Get(int ID);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(params TEntity[] entities);

        void Edit(TEntity newEntity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
       
        void RemoveAll();

        void SaveChanges();
    }
}
