using Alamut.Data.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainServices.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GEtById();

        ServiceResult<int> Create(T entity);

        ServiceResult<int> Edit(T entity);

        ServiceResult<int> Delete(T entity);

        void Save();

    }
}
