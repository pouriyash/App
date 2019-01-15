using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using App.DomainModels.Entities;

namespace App.DomainServices.Repositories
{
    public class InfoRepository : BaseRepository<Person>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<Info> _Info;
        public InfoRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
            _Info = Context.Set<Info>();
        }

        public Info Get()
        {
            return _Info.FirstOrDefault();
        }

        public ServiceResult Edit(InfoViewModel model,int Id)
        {
            var entity = _Info.Find(Id);

            if (entity==null)
            {
                var newModel = new Info();
                Mapper.Map(newModel, entity);
                _Info.Add(newModel);
                _Context.SaveChanges();
                return ServiceResult.Okay();
            }

            Mapper.Map(model, entity);
            _Info.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }


    }
}
