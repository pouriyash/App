using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Models;
using App.DomainModels.Entities.Products;
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
    public class ProductTypeRepository : BaseRepository<Person>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<ProductType> _productType;
        public ProductTypeRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
            _productType = Context.Set<ProductType>();
        }

        public List<ProductTypeDTO> GetAll()
        {
            var model= _productType.ProjectTo<ProductTypeDTO>().ToList();
            return model;
        }

        public ServiceResult Create(ProductTypeDTO model)
        {
            var entity = new ProductType();

            Mapper.Map(model, entity);

            _productType.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public ServiceResult Edit(ProductTypeEditViewModel model,int Id)
        {
            var entity = _productType.Find(Id);
            Mapper.Map(model, entity);

            _productType.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult Delete(int Id)
        {
            var entity = _productType.Find(Id);

            _productType.Remove(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

    }
}
