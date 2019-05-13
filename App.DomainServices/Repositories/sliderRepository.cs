using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Dto;
using App.DomainModels.Entities;
using App.DomainModels.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.DomainServices.Repositories
{
    public class sliderRepository : BaseRepository<Slider>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<Slider> _slider;
        public sliderRepository(IUnitOfWork Context) : base(Context)
        {
            _Context = Context;
            _slider = Context.Set<Slider>();
        }

        public List<sliderDTO> GetAll()
        {
            var model = _slider
                .OrderBy(p => p.Order)
                .Where(p=>p.IsActive)
                .ProjectTo<sliderDTO>()
                .ToList();
            return model;
        }

        public ServiceResult Create(sliderDTO model)
        {
            var entity = new Slider();

            Mapper.Map(model, entity);

            _slider.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public sliderDTO GetById(int Id)
        {
            return _slider
                .Where(p => p.Id == Id)
                .ProjectTo<sliderDTO>()
                .FirstOrDefault();
        }

        public ServiceResult Edit(sliderViewModel model, int Id)
        {
            var entity = _slider.Find(Id);
            Mapper.Map(model, entity);

            _slider.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult Delete(int Id)
        {
            var entity = _slider.Find(Id);

            _slider.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult.Okay();
            return ServiceResult.Error();
        }

    }
}
