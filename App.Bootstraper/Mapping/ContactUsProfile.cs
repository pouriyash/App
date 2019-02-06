using App.DomainModels.Dto.Blogs;
using App.DomainModels.Dto.ContactUs;
using App.DomainModels.Entities;
using App.DomainModels.Entities.Blogs;
using App.DomainModels.ViewModels.Blogs;
using App.DomainModels.ViewModels.ContactUs;
using AutoMapper;

namespace App.Bootstraper.Mapping
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            CreateMap<ContactUsViewModel, ContactUs>().ReverseMap();
            CreateMap<ContactUsSummaryDTO, ContactUs>().ReverseMap();

        }
    }
}
