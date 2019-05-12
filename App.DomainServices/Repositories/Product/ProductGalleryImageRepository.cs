using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Products;
using App.DomainModels.ViewModels.Product;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;  
using System.Collections.Generic;
using System.Linq; 

namespace App.DomainServices.Repositories
{
    public class ProductGalleryImageRepository : BaseRepository<ProductGalleryImage>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<ProductGalleryImage> _ProductGalleryImage;
        public ProductGalleryImageRepository(IUnitOfWork Context) : base(Context)
        {
            _Context = Context;
            _ProductGalleryImage = Context.Set<ProductGalleryImage>();
        }

        public List<ProductGalleryImageDTO> GetAll(int productId)
        {
            var model = _ProductGalleryImage
                .Where(p => p.ProductId == productId)
                .OrderBy(p => p.Alt)
                .ProjectTo<ProductGalleryImageDTO>()
                .ToList();
            return model;
        }

        public ServiceResult Create(ProductGalleryImageDTO model)
        {
            var entity = new ProductGalleryImage();

            Mapper.Map(model, entity);

            _ProductGalleryImage.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public ProductGalleryImageDTO GetById(int Id)
        {
            return _ProductGalleryImage
                .Where(p => p.Id == Id)
                .ProjectTo<ProductGalleryImageDTO>()
                .FirstOrDefault();
        }
        
        public ServiceResult<int> Delete(int Id)
        {
            var entity = _ProductGalleryImage.Find(Id);

            _ProductGalleryImage.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult<int>.Okay(entity.ProductId.Value);
            return ServiceResult<int>.Error("خطا در انجام عملیات");
        }

        public ServiceResult<int> DeleteByProductId(int productId)
        {
            var list = _ProductGalleryImage.Where(p=>p.ProductId== productId).ToList();

            _ProductGalleryImage.RemoveRange(list);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult<int>.Okay(productId);
            return ServiceResult<int>.Error("خطا در انجام عملیات");
        }
    }
}
