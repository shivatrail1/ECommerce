using ECommerce.Service.Models.Dto;
using ECommerce.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ECommerce.Service.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }

}
