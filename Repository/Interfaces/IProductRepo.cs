using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WholesaleEcomBackend.Data.Interfaces
{
    public interface IProductRepo
    {
        public PagedList<Product> SearchProductsWithPaging(ProductParameters productParameters);
        public Product GetProductById(int id);
        public Product CreateProduct(Product product);
        public PagedList<Product> GetProductsBySubsubcategoryIdWithPagingAndFilters(int subsubcategoryId, ProductParameters productParameters);
        public List<Product> GetAllProductsBySubsubcategoryId(int subsubcategoryId, ProductParameters productParameters);

    }
}
