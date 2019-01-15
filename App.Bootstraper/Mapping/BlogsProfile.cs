using App.DomainModels.Dto.Blogs;
using App.DomainModels.Entities.Blogs;
using App.DomainModels.ViewModels.Blogs;
using AutoMapper;

namespace App.Bootstraper.Mapping
{
    public class BlogsProfile : Profile
    {
        public BlogsProfile()
        {
            CreateMap<BlogsViewModel, Blogs>().ReverseMap();
            CreateMap<BlogsDTO, Blogs>().ReverseMap();


            CreateMap<BlogGalleryViewModel, BlogsGallery>().ReverseMap();
            CreateMap<BlogGalleryDTO, BlogsGallery>().ReverseMap();

        }
    }
}
