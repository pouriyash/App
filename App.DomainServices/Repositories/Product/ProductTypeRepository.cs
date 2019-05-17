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
    public class ProductTypeRepository : BaseRepository<ProductType>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<ProductType> _productType;
        public ProductTypeRepository(IUnitOfWork Context) : base(Context)
        {
            _Context = Context;
            _productType = Context.Set<ProductType>();
        }

        public List<ProductTypeDTO> GetAll(int? parentId)
        {
            var model = new List<ProductTypeDTO>();

            if (parentId == null)
            {
                model = _productType
                  .OrderBy(p => p.Title)
                  .ProjectTo<ProductTypeDTO>()
                  .ToList();
            }
            else
            {
                model = _productType
                 .OrderBy(p => p.Title)
                 .Where(p=>p.ParentId==parentId)
                 .ProjectTo<ProductTypeDTO>()
                 .ToList();
            }

            return model;
        }

        public List<ProductTypeDTO> GetList()
        {
            return _productType
                  .OrderBy(p => p.Title)
                  .Where(p=>p.ParentId!=null)
                  .ProjectTo<ProductTypeDTO>()
                  .ToList();
        }

        public ServiceResult Create(ProductTypeDTO model)
        {
            var entity = new ProductType();

            Mapper.Map(model, entity);

            _productType.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public ProductTypeDTO GetById(int Id)
        {
            return _productType
                .Where(p => p.Id == Id)
                .ProjectTo<ProductTypeDTO>()
                .FirstOrDefault();
        }

        public ServiceResult Edit(ProductTypeEditViewModel model, int Id)
        {
            var entity = _productType.Find(Id);
            Mapper.Map(model, entity);

            _productType.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult<int?> Delete(int Id)
        {
            try
            {
                var entity = _productType.Find(Id);

                _productType.Remove(entity);
                _Context.SaveChanges();
                return ServiceResult<int?>.Okay(entity.ParentId.Value);
            }
            catch (Exception)
            {
                return ServiceResult<int?>.Error("حطایی در انجام عملیات رخ داده است");
            }
        }

    }
}
