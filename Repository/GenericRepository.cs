using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Web;
using Model;

namespace Repository
{
    public class GenericRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        private HRMSEntities _dbContext;
        private int _totalRowCount = 0;

        public HRMSEntities Context
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new HRMSEntities();
                }
                return _dbContext;
            }
            set { _dbContext = value; }
        }

        public GenericRepository()
        {
        }

        public GenericRepository(HRMSEntities context)
        {
            if (context == null) throw new ArgumentNullException("dbContext");
            _dbContext = context;
        }

        public virtual void SaveChanges()
        {
            if (_dbContext == null) throw new ArgumentNullException("_dbContext");
            _dbContext.SaveChanges();
        }

        public object GetEntityKey(TEntity entity)
        {
            var oc = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_dbContext).ObjectContext;
            return oc.ObjectStateManager.GetObjectStateEntry(entity).EntityKey.EntityKeyValues[0].Value;
        }

        public virtual TKey SaveChangesReturnId(TEntity entity)
        {
            this.SaveChanges();
            return (TKey)this.GetEntityKey(entity);
        }


        public virtual ICollection<TEntity> Get()
        {
            return this.Get(null, null, p => 0 == 0, null, string.Empty);
        }

        public virtual ICollection<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return this.Get(null, null, filter, null, string.Empty);
        }

        public virtual ICollection<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return this.Get(null, null, filter, orderBy, string.Empty);
        }

        public virtual ICollection<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            return this.Get(null, null, filter, orderBy, includeProperties);
        }

        public virtual ICollection<TEntity> Get(
            int? pageIndex,
            int? pageSize,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            _totalRowCount = query.Count();
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                query = query.Skip((int)pageIndex * (int)pageSize).Take((int)pageSize);
            }

            return query.ToList();
        }

        public IQueryable<TEntity> Get(string filter)
        {
            return this.Get(null, null, filter, null, string.Empty);
        }

        public IQueryable<TEntity> Get(string filter, string orderBy)
        {
            return this.Get(null, null, filter, orderBy, string.Empty);
        }

        public IQueryable<TEntity> Get(string filter, string orderBy, string includeProperties = "")
        {
            return this.Get(null, null, filter, orderBy, includeProperties);
        }



        public IQueryable<TEntity> Get(int? pageIndex, int? pageSize, string filter, string orderBy, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.Context.Set<TEntity>();

            if (filter != null && filter != string.Empty && filter != "null")
            {
                query = query.Where(filter);

            }

            if (!String.IsNullOrEmpty(includeProperties) && includeProperties != "null")
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            _totalRowCount = query.Count();
            if (orderBy != null && orderBy != string.Empty && orderBy != "null")
            {
                query = query.OrderBy(orderBy);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                query = query.Skip((int)pageIndex * (int)pageSize).Take((int)pageSize);
            }

            return query;
        }

        public virtual TEntity GetById(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            // TBD:  Need to update in the future to avoid querying the object before delete
            TEntity obj = Context.Set<TEntity>().Find(id);
            this.Delete(obj);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public int TotalRowCount
        {
            get { return _totalRowCount; }
            set { _totalRowCount = value; }
        }
    }
}