using AutoMapper;
using WholesaleEcomBackend.Dtos;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Profiles
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            /*Create Dtos*/
            CreateMap<ProductCreateDto, Product>();
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<SubCategoryCreateDto, SubCategory>();
            CreateMap<SubSubCategoryCreateDto, SubSubCategory>();
            CreateMap<CharacteristicCreateDto, Characteristic>();
            CreateMap<ProductCharacteristicCreateDto, ProductCharacteristic>();
            CreateMap<UserForRegistrationDto, User>();

            /*Read Dtos*/
            CreateMap<Brand, BrandReadDto>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<Characteristic, CharacteristicReadDto>();

            CreateMap<ProductCharacteristic, ProductCharacteristicReadDto>()
                .ForMember(dest => dest.CharacteristicName, opt => opt.MapFrom(src => src.Characteristic.Name));

            /*ProductCharacteristicReadDto*/

            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));

            CreateMap<SubCategory, SubCategoryReadDto>();
            CreateMap<SubSubCategory, SubSubCategoryReadDto>();




        }


    }
}
