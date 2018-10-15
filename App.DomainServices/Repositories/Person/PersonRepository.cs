using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.DomainServices.Repositories
{
    public class PersonRepository: BaseRepository<Person>
    {
        private readonly IUnitOfWork _Context;
        public PersonRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
        }
    }
}
