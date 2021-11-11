using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository
{
    using System.Data.Entity;
    using System.Linq.Expressions;

    public class Repository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IEntity
    {
        public Repository(TDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Save changes automatically when Add, Edit or Remove is called.
        /// </summary>
        public bool SaveChangesOnAddEditRemove = true;

        protected TDbContext Context { get; set; }

        public TEntity Get(int ID)
        {
            return this.Context.Set<TEntity>().Find(ID);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);

            if (this.SaveChangesOnAddEditRemove)
                this.Context.SaveChanges();
        }

        public void AddRange(params TEntity[] entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);

            if (this.SaveChangesOnAddEditRemove)
                this.Context.SaveChanges();
        }

        public void Edit(TEntity newEntity)
        {
            TEntity currentVal = Get(newEntity.ID);

            if (currentVal == null)
                throw new ArgumentNullException("Invalid entity. No entity exists by ID.");

            currentVal = newEntity;

            if (this.SaveChangesOnAddEditRemove)
                this.Context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);

            if (this.SaveChangesOnAddEditRemove)
                this.Context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);

            if (this.SaveChangesOnAddEditRemove)
                this.Context.SaveChanges();
        }

        public virtual void RemoveAll()
        {
            this.Context.Set<TEntity>().RemoveRange(this.GetAll());

            if (this.SaveChangesOnAddEditRemove)
                this.Context.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
