using System.Collections;
using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;

namespace WholesaleEcomBackend.Services.Interfaces
{
    public interface IProductService
    {
        (List<ProductReadDto> products, MetaData metaData) SearchProducts(ProductParameters productParameters);
        ProductReadDto GetProductById(int id);
        ProductReadDto CreateProduct(ProductCreateDto productCreateDto);
        (List<ProductReadDto> products, MetaData metaData) GetProductsBySubsubcategoryIdWithPagingAndFilters(int subsubcategoryId, ProductParameters productParameters);
        IList GetCharacteristicStatisticsOfProductsInSubsubcategory(int subsubcategoryId, ProductParameters productParameters);
        IList GetBrandsStatisticsOfProductsInSubsubcategory(int subsubcategoryId, ProductParameters productParameters);

    }
}
