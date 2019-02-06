using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Dto.ContactUs;
using App.DomainModels.Dto.Person;
using App.DomainModels.Entities;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels.ContactUs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.DomainServices.Repositories
{
    public class ContactUsRepository : BaseRepository<Person>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<ContactUs> _contactUs;
        public ContactUsRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
            _contactUs= Context.Set<ContactUs>();
        }

        public List<ContactUsSummaryDTO> GetAll()
        {
            var model= _contactUs.ProjectTo<ContactUsSummaryDTO>().ToList();
            return model;
        }

        public ServiceResult Create(ContactUsViewModel model)
        {
            var entity = new ContactUs();

            Mapper.Map(model, entity);

            _contactUs.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public ContactUsSummaryDTO GetById(int Id)
        {
            return _contactUs.Where(p => p.Id == Id).ProjectTo<ContactUsSummaryDTO>().FirstOrDefault();
        }

        public ServiceResult Edit(ContactUsViewModel model, int Id)
        {
            var entity = _contactUs.Find(Id);
            Mapper.Map(model, entity);

            _contactUs.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult Delete(int Id)
        {
            var entity = _contactUs.Find(Id);

            _contactUs.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult.Okay();
            return ServiceResult.Error();
        }
    }
}
