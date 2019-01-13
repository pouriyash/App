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
using System.Threading.Tasks;

namespace App.DomainServices.Repositories
{
    public class BlogsRepository : BaseRepository<Blogs>
    {
        private readonly IUnitOfWork _Context;
        private readonly DbSet<Blogs> _blogs;
        public BlogsRepository(IUnitOfWork Context) : base(Context)
        {
            _Context = Context;
            _blogs = Context.Set<Blogs>();
        }

        public List<BlogsDTO> GetAll()
        {
            var model = _blogs
                .OrderBy(p => p.Title)
                .ProjectTo<BlogsDTO>()
                .ToList();
            return model;
        }

        public ServiceResult Create(BlogsDTO model)
        {
            var entity = new Blogs();

            Mapper.Map(model, entity);

            _blogs.Add(entity);
            _Context.SaveChanges();

            return ServiceResult.Okay();
        }

        public BlogsDTO GetById(int Id)
        {
            return _blogs
                .Where(p => p.Id == Id)
                .ProjectTo<BlogsDTO>()
                .FirstOrDefault();
        }

        public ServiceResult Edit(BlogsViewModel model, int Id)
        {
            var entity = _blogs.Find(Id);
            Mapper.Map(model, entity);

            _blogs.Update(entity);
            _Context.SaveChanges();
            return ServiceResult.Okay();
        }

        public ServiceResult Delete(int Id)
        {
            var entity = _blogs.Find(Id);

            _blogs.Remove(entity);
            var result = _Context.SaveChanges();
            if (result > 0)
                return ServiceResult.Okay();
            return ServiceResult.Error();
        }

        public int View(int Id)
        {
            return _blogs.Find(Id).View;
        }

        public BlogsDTO GetByIdToShowUSer(int Id)
        {
            
            return _blogs
                .Where(p => p.Id == Id)
                .ProjectTo<BlogsDTO>()
                .FirstOrDefault();
        }

        public void AddNumberOfView(int Id)
        {
            var entity = _blogs.Find(Id);
            entity.View++;
            _Context.Entry<Blogs>(entity).State = EntityState.Modified;
            var result=_Context.SaveChanges();
        }
    }
}
