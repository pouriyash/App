using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Models;
using App.DomainModels.Entities.Products;
using App.DomainModels.ViewModels;
using App.DomainModels.ViewModels.Product;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.DomainServices.Repositories
{
    public class ProductColorRepository : BaseRepository<Person>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<ProductColor> _productColor;
        public ProductColorRepository(IUnitOfWork Context) :base(Context)
        {
            _Context = Context;
            _productColor = Context.Set<ProductColor>();
        }

        public List<ProductColorSummaryDTO> GetAll(int productId)
        {
            var model= _productColor
                .OrderBy(p=>p.Title)
                .Where(p=>p.ProductId== productId)
                .ProjectTo<ProductColorSummaryDTO>()
                .ToList();
            return model;
        }
        
        public ServiceResult Create(ProductColorSummaryDTO model)
        {
            var entity = new ProductColor();

            Mapper.Map(model, entity);

            _productColor.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public ProductColorSummaryDTO GetById(int Id)
        {
            return _productColor
                .Where(p => p.Id == Id)
                .ProjectTo<ProductColorSummaryDTO>()
                .FirstOrDefault();
        }

        public ServiceResult Edit(ProductColorEditViewModel model,int Id)
        {
            var entity = _productColor.Find(Id);
            Mapper.Map(model, entity);

            _productColor.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult<int> Delete(int Id)
        {
            var entity = _productColor.Find(Id);

            _productColor.Remove(entity);
            _Context.SaveChanges();
            return ServiceResult<int>.Okay(entity.ProductId.Value);
        }

    }
}
