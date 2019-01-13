﻿using App.DomainModels.Dto.Blogs;
using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Blogs;
using App.DomainModels.Entities.Products;
using App.DomainModels.ViewModels;
using App.DomainModels.ViewModels.Blogs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bootstraper.Mapping
{
    public class BlogsProfile : Profile
    {
        public BlogsProfile()
        {
            CreateMap<BlogsViewModel, Blogs>().ReverseMap();
            CreateMap<BlogsDTO, Blogs>().ReverseMap();
             
        }
    }
}
