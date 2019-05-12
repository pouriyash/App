using Alamut.Data.Structure;
using App.Data.Sql.Context;
using App.DomainModels.Dto.Blogs;
using App.DomainModels.Entities.Blogs;
using App.DomainModels.ViewModels.Blogs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App.DomainServices.Repositories
{
    public class BlogGalleryRepository : BaseRepository<BlogsGallery>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<BlogsGallery> _blogGallery;
        public BlogGalleryRepository(IUnitOfWork Context) : base(Context)
        {
            _Context = Context;
            _blogGallery = Context.Set<BlogsGallery>();
        }

        public List<BlogGalleryDTO> GetAll(int blogId)
        {
            var model = _blogGallery
                .Where(p=>p.BlogId== blogId)
                .OrderBy(p => p.Alt)
                .ProjectTo<BlogGalleryDTO>()
                .ToList();
            return model;
        }

        public ServiceResult Create(BlogGalleryDTO model)
        {
            var entity = new BlogsGallery();

            Mapper.Map(model, entity);

            _blogGallery.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public BlogGalleryDTO GetById(int Id)
        {
            return _blogGallery
                .Where(p => p.Id == Id)
                .ProjectTo<BlogGalleryDTO>()
                .FirstOrDefault();
        }

        public ServiceResult<int> Delete(int Id)
        {
            var entity = _blogGallery.Find(Id);

            _blogGallery.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult<int>.Okay(entity.BlogId);
            return ServiceResult<int>.Error("خطا در انجام عملیات");
        }

        public ServiceResult<int> DeleteByBlogId(int blogId)
        {
            var list = _blogGallery.Where(p=>p.BlogId== blogId).ToList();

            _blogGallery.RemoveRange(list);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult<int>.Okay(blogId);
            return ServiceResult<int>.Error("خطا در انجام عملیات");
        }

    }
}
