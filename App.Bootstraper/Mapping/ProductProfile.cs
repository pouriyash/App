using App.DomainModels.Dto.Product;
using App.DomainModels.Entities.Products;
using App.DomainModels.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bootstraper.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductTypeDTO, ProductType>().ReverseMap();
            CreateMap<ProductTypeEditViewModel, ProductType>().ReverseMap();

            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<ProductEditViewModel, Product>().ReverseMap();
        }
    }
}
