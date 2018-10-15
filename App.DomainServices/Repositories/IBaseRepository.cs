using Alamut.Data.Structure;
using App.Data.Sql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace App.DomainServices.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GEtById(int Id);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        ServiceResult<int> Create(T entity);

        ServiceResult<int> Edit(T entity);

        ServiceResult<int> Delete(T entity);

        void Save();

    }
}
