using App.DomainModels.Dto;
using App.DomainModels.Entities;
using App.DomainModels.ViewModels;
using AutoMapper;

namespace App.Bootstraper.Mapping
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<sliderViewModel, Slider>().ReverseMap();
            CreateMap<sliderDTO, Slider>().ReverseMap();
             
        }
    }
}
