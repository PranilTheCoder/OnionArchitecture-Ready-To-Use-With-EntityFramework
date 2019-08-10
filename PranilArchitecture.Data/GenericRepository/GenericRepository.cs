using LinqKit;
using PranilArchitecture.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PranilArchitecture.Data
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private member

        private TestEntities context;
        private DbSet<TEntity> dbSet;

        #endregion

        #region Public Constructor

        public GenericRepository(TestEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Public member methods

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = this.dbSet;
            return query.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.dbSet.Attach(entityToDelete);
            }

            this.dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return this.dbSet.Where(where).ToList();
        }

        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return this.dbSet.Where(where).AsQueryable();
        }

        public virtual IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = this.dbSet;
            return query.AsExpandable().Where(predicate) as IQueryable<TEntity>;
        }

        public TEntity Get(Func<TEntity, bool> where)
        {
            return this.dbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public void Delete(Func<TEntity, bool> where)
        {
            IQueryable<TEntity> objects = this.dbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
            {
                this.dbSet.Remove(obj);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.dbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public bool Exists(object primaryKey)
        {
            return this.dbSet.Find(primaryKey) != null;
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return this.dbSet.Single<TEntity>(predicate);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return this.dbSet.FirstOrDefault<TEntity>(predicate);
        }

        #endregion
    }
}
