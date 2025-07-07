using AssetSystem.Application.DTOs;
using FixedAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace AssetSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Asset, AssetDto>()
            //    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            //    .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))
            //    .ForMember(des => des.PurchaseDate, opt => opt.MapFrom(src => src.PurchasDate.ToString("yyyy-MM-dd")));
            CreateMap<Asset, AssetDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate.ToString("yyyy-MM-dd")));

            //CreateMap<CreateAssetDto, Asset>()
            //  .ForMember(dest => dest.PurchasDate, opt => opt.MapFrom(src => src.PurchaseDate)); 

            //CreateMap<UpdateAssetDto, Asset>()
            //  .ForMember(dest => dest.PurchasDate, opt => opt.MapFrom(src => src.PurchaseDate)); 


            CreateMap<CreateAssetDto, Asset>();
            CreateMap<UpdateAssetDto, Asset>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Location, LocationDto>();
            CreateMap<CreateLocationDto, Location>();
            CreateMap<UpdateLocationDto, Location>();

            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>().ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            CreateMap<UpdateUserDto, User>();
        }
    }
}
