using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleEcomBackend.Services.Interfaces
{
    public interface IBrandService
    {
        (IEnumerable<BrandReadDto> brands, MetaData metaData) GetBrandsWithPaging(BrandParameters brandParameters);
        BrandReadDto GetBrandById(int id);
        BrandReadDto CreateBrand(BrandCreateDto brandCreateDto);
    }
}
