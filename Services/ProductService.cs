using AutoMapper;
using System.Collections;
using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;

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

        public (List<ProductReadDto> products, MetaData metaData) SearchProducts(ProductParameters productParameters)
        {
            var productsSearchedWithMetaData = _productRepo.SearchProductsWithPaging(productParameters);
            var productsReadDtos = _mapper.Map<List<Product>, List<ProductReadDto>>(productsSearchedWithMetaData.ToList());

            return (products: productsReadDtos, metaData: productsSearchedWithMetaData.MetaData);
        }

        public (List<ProductReadDto> products, MetaData metaData) GetProductsBySubsubcategoryIdWithPagingAndFilters(int subsubcategoryId, ProductParameters productParameters)
        {
            var productsWithMetaData = _productRepo.GetProductsBySubsubcategoryIdWithPagingAndFilters(subsubcategoryId, productParameters);
            var productsReadDtos = _mapper.Map<List<Product>, List<ProductReadDto>>(productsWithMetaData.ToList());

            return (products: productsReadDtos, metaData: productsWithMetaData.MetaData);

        }

        public IList GetCharacteristicStatisticsOfProductsInSubsubcategory(int subsubcategoryId, ProductParameters productParameters)
        {
            var productsOfSubsubcategory = _productRepo.GetAllProductsBySubsubcategoryId(subsubcategoryId, productParameters);

            var query = from product in productsOfSubsubcategory
                        from productCharacteristic in product.ProductCharacteristics
                        where productCharacteristic.Characteristic.DisplayInFilters == true
                        group productCharacteristic by new { productCharacteristic.CharacteristicId, productCharacteristic.Characteristic.Name } into group1
                        orderby group1.Key.CharacteristicId, group1.Key.Name
                        select new
                        {
                            group1.Key.CharacteristicId,
                            CharacteristicName = group1.Key.Name,
                            Counts = from CharacValues in group1
                                     group CharacValues by CharacValues.CharacteristicValue into group2
                                     orderby group2.Key
                                     select new
                                     {
                                         Value = group2.Key,
                                         Count = group2.Count()
                                     }
                        };

            var listCharacteristicsStatistics = query.ToList();

            return listCharacteristicsStatistics;

        }

        public IList GetBrandsStatisticsOfProductsInSubsubcategory(int subsubcategoryId, ProductParameters productParameters)
        {
            var productsOfSubsubcategory = _productRepo.GetAllProductsBySubsubcategoryId(subsubcategoryId, productParameters);
            
            var query = from product in productsOfSubsubcategory
                        group product by new { product.BrandId, product.Brand.Name } into grp
                        orderby grp.Key.Name
                        select new
                        {
                            grp.Key.BrandId,
                            BrandName = grp.Key.Name,
                            Count = grp.Count()
                        };

            var listBrandsStatistics = query.ToList();

            return listBrandsStatistics;

        }
    }
}
