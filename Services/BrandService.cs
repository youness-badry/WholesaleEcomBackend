using AutoMapper;
using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;

namespace WholesaleEcomBackend.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepo _brandRepo;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepo brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public BrandReadDto CreateBrand(BrandCreateDto brandCreateDto)
        {
            var newBrand = _mapper.Map<Brand>(brandCreateDto);
            _brandRepo.CreateBrand(newBrand);
            return _mapper.Map<BrandReadDto>(newBrand);
        }

        public (IEnumerable<BrandReadDto> brands, MetaData metaData) GetBrandsWithPaging(BrandParameters brandParameters)
        {
            var brandsWithMetaData = _brandRepo.GetBrandsWithPaging(brandParameters);
            var BrandsReadDtos = _mapper.Map<List<Brand>, List<BrandReadDto>>(brandsWithMetaData.ToList());
            return (brands: BrandsReadDtos, metaData: brandsWithMetaData.MetaData); 
        }

        public BrandReadDto GetBrandById(int id)
        {
            var brand = _brandRepo.GetBrandById(id);
            return _mapper.Map<BrandReadDto>(brand);
            
        }
    }
}
