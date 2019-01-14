using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Entities.Models;
using App.DomainModels.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.DomainModels.Entities;
using App.DomainModels.Dto;

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

        public List<InfoDTO> GetAll()
        {
            var model= _Info.ProjectTo<InfoDTO>().ToList();
            return model;
        }

        public ServiceResult Create(InfoDTO model)
        {
            var entity = new Info();

            Mapper.Map(model, entity);

            _Info.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public InfoDTO GetById(int Id)
        {
            return _Info.Where(p => p.Id == Id).ProjectTo<InfoDTO>().FirstOrDefault();
        }

        public ServiceResult Edit(InfoViewModel model,int Id)
        {
            var entity = _Info.Find(Id);
            Mapper.Map(model, entity);

            _Info.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult Delete(int Id)
        {
            var entity = _Info.Find(Id);

            _Info.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult.Okay();
            return ServiceResult.Error();
        }

    }
}
