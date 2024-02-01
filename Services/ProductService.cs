using AutoMapper;
using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WholesaleEcomBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public ProductReadDto CreateProduct(ProductCreateDto productCreateDto)
        {
            var newProduct = _mapper.Map<Product>(productCreateDto);
            _productRepo.CreateProduct(newProduct);
            return _mapper.Map<ProductReadDto>(newProduct);
        }

        public ProductReadDto GetProductById(int id)
        {
            var product = _productRepo.GetProductById(id);
            return _mapper.Map<ProductReadDto>(product);
        }

        public (List<ProductReadDto> products, MetaData metaData) GetProductsWithPaging(ProductParameters productParameters)
        {
            var productsWithMetaData = _productRepo.GetProductsWithPaging(productParameters);
            var productsReadDtos = _mapper.Map<List<Product>, List<ProductReadDto>>(productsWithMetaData.ToList());

            return (products: productsReadDtos, metaData: productsWithMetaData.MetaData);

        }

        public (List<ProductReadDto> products, MetaData metaData) GetProductsWithFilterAndPaging(ProductParameters productParameters)
        {
            if (!productParameters.ValidPriceRange)
                throw new MaxPriceRangeBadRequestException();

            var productsWithMetaData = _productRepo.GetProductsWithFilterAndPaging(productParameters);
            var productsReadDtos = _mapper.Map<List<Product>, List<ProductReadDto>>(productsWithMetaData.ToList());

            return (products: productsReadDtos, metaData: productsWithMetaData.MetaData);

        }

        public (List<ProductReadDto> products, MetaData metaData) SearchProducts(ProductParameters productParameters)
        {
            var productsSearchedWithMetaData = _productRepo.SearchProducts(productParameters);
            var productsReadDtos = _mapper.Map<List<Product>, List<ProductReadDto>>(productsSearchedWithMetaData.ToList());

            return (products: productsReadDtos, metaData: productsSearchedWithMetaData.MetaData);
        }
    }
}
