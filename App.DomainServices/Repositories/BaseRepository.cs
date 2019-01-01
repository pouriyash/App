using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Alamut.Data.Structure;
using App.Data.Sql.Context;

namespace App.DomainServices.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _context;
      
        public BaseRepository(IUnitOfWork context)
        {
            _context = context;
        }
        public virtual ServiceResult<int> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            var result = _context.SaveChanges();
            return new ServiceResult<int>();

        }
         
        public virtual ServiceResult<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            var result = _context.SaveChanges();
            return new ServiceResult<int>();
        }

        public virtual ServiceResult<int> Edit(T entity)
        {
            _context.Set<T>().Update(entity);
            var result = _context.SaveChanges();
            return new ServiceResult<int>();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual T GEtById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

   
    }
}
