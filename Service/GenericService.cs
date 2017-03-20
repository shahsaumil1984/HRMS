using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public abstract class GenericService<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        protected GenericRepository<TEntity, TKey> repository = new GenericRepository<TEntity, TKey>();
        protected int _totalRowCount = 0;

        public virtual ICollection<TEntity> Get()
        {
            return repository.Get();
        }

        public HRMSEntities Context
        {
            get { return repository.Context; }
            set { repository.Context = value; }
        }

        public GenericService()
        {

        }

        public GenericService(HRMSEntities context)
        {
            repository.Context = context;
        }

        public virtual ICollection<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return repository.Get(null, null, (p => 0 == 0), null, string.Empty);
        }

        public virtual ICollection<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return repository.Get(null, null, filter, orderBy, string.Empty);
        }

        public virtual ICollection<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            return repository.Get(null, null, filter, orderBy, includeProperties);
        }

        public virtual ICollection<TEntity> Get(
            int? pageIndex,
            int? pageSize,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            ICollection<TEntity> query = repository.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            _totalRowCount = repository.TotalRowCount;
            return query;
        }

        public virtual IQueryable<TEntity> Get(string filter)
        {
            return repository.Get(null, null, filter, null, string.Empty);
        }

        public virtual IQueryable<TEntity> Get(string filter, string orderBy)
        {
            return repository.Get(null, null, filter, orderBy, string.Empty);
        }

        public virtual IQueryable<TEntity> Get(string filter, string orderBy, string includeProperties = "")
        {
            return repository.Get(null, null, filter, orderBy, includeProperties);
        }

        public virtual IQueryable<TEntity> Get(int? pageIndex, int? pageSize, string filter, string orderBy, string includeProperties = "")
        {
            IQueryable<TEntity> query = repository.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            _totalRowCount = repository.TotalRowCount;
            return query;
        }

        public virtual TEntity GetById(TKey id)
        {
            TEntity obj = repository.GetById(id);
            return obj;
        }

        public virtual void Create(TEntity entity)
        {
            Validate(entity);
            repository.Create(entity);

        }

        public virtual void Update(TEntity entity)
        {
            Validate(entity);
            repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            repository.Delete(id);
        }

        public virtual void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public virtual void SaveChanges()
        {
            repository.SaveChanges();
        }

        public virtual TKey SaveChangesReturnId(TEntity entity)
        {
            return this.repository.SaveChangesReturnId(entity);
        }

        public virtual bool Validate(TEntity entity)
        {
            return true;
        }

        public void Dispose()
        {
            if (repository != null)
            {
                repository.Dispose();
            }
        }

        public int TotalRowCount
        {
            get { return _totalRowCount; }
            set { _totalRowCount = value; }
        }
    }
}
