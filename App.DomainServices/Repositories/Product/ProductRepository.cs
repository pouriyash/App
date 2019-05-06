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
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<Product> _Product;
        public ProductRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
            _Product = Context.Set<Product>();
        }

        public List<ProductDTO> GetAll()
        {
            var model= _Product.ProjectTo<ProductDTO>().ToList();
            return model;
        }

        public ServiceResult Create(ProductDTO model)
        {
            var entity = new Product();

            Mapper.Map(model, entity);

            _Product.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public ProductDTO GetById(int Id)
        {
            return _Product.Where(p => p.Id == Id).ProjectTo<ProductDTO>().FirstOrDefault();
        }

        public ServiceResult Edit(ProductEditViewModel model,int Id)
        {
            var entity = _Product.Find(Id);
            Mapper.Map(model, entity);

            _Product.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult Delete(int Id)
        {
            var entity = _Product.Find(Id);

            _Product.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult.Okay();
            return ServiceResult.Error();
        }

    }
}
