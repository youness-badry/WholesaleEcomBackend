using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WholesaleEcomBackend.Data.Interfaces
{
    public interface IProductRepo
    {
        public PagedList<Product> GetProductsWithPaging(ProductParameters productParameters);
        public PagedList<Product> GetProductsWithFilterAndPaging(ProductParameters productParameters);
        public PagedList<Product> SearchProducts(ProductParameters productParameters);
        public Product GetProductById(int id);
        public Product CreateProduct(Product product);

    }
}
