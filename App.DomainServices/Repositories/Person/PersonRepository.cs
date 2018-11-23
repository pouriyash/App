using App.Data.Sql.Context;
using App.DomainModels.Dto.Person;
using App.DomainModels.Entities.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.DomainServices.Repositories
{
    public class PersonRepository: BaseRepository<Person>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<Person> _person;
        public PersonRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
            _person = Context.Set<Person>();
        }

        public IEnumerable<PersonSummary> GetAlla()
        {
            return _person.ProjectTo<PersonSummary>().ToList();
        }

    }
}
