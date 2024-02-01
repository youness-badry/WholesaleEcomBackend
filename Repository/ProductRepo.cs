using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace WholesaleEcomBackend.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _storeContext;

        public ProductRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Product GetProductById(int id)
        {
            return _storeContext.Products
                        .Include(pr => pr.Brand)
                        .Include(pr => pr.Characteristics)
                        .ThenInclude(c => c.ProductCharacteristics)
                        .Include(pr => pr.SubSubCategory)
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

        }

        public Product CreateProduct(Product product)
        {
            _storeContext.Products.Add(product);
            _storeContext.SaveChanges();
            return product;
        }

        public PagedList<Product> GetProductsWithPaging(ProductParameters productParameters)
        {
            var products = _storeContext.Products
                .OrderBy(pr => pr.Name)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .Include(pr => pr.Brand)
                .Include(pr => pr.Characteristics)
                .ThenInclude(c => c.ProductCharacteristics)
                .Include(pr => pr.SubSubCategory)
                .ToList();

            var count = _storeContext.Products.Count();

            return new PagedList<Product>(products, count, productParameters.PageNumber, productParameters.PageSize);

        }

        public PagedList<Product> GetProductsWithFilterAndPaging(ProductParameters productParameters)
        {
            var productsFiltered = _storeContext.Products
                                .Where(pr => pr.Price >= productParameters.MinPrice
                                            && pr.Price <= productParameters.MaxPrice)
                                .OrderBy(pr => pr.Name)
                                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                                .Take(productParameters.PageSize)
                                .Include(pr => pr.Brand)
                                .Include(pr => pr.Characteristics)
                                .ThenInclude(c => c.ProductCharacteristics)
                                .Include(pr => pr.SubSubCategory)
                                .ToList();

            
            var count = _storeContext.Products
                        .Where(pr => pr.Price >= productParameters.MinPrice
                                && pr.Price <= productParameters.MaxPrice)
                        .Count();

            return new PagedList<Product>(productsFiltered, count, productParameters.PageNumber, productParameters.PageSize);

        }

        public PagedList<Product> SearchProducts(ProductParameters productParameters)
        {
            List<Product> productsSearched;
            int count;

            if (string.IsNullOrWhiteSpace(productParameters.SearchTerm))
            {

                productsSearched = _storeContext.Products
                                    .OrderBy(pr => pr.Name)
                                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                                    .Take(productParameters.PageSize)
                                    .Include(pr => pr.Brand)
                                    .Include(pr => pr.Characteristics)
                                    .ThenInclude(c => c.ProductCharacteristics)
                                    .Include(pr => pr.SubSubCategory)
                                    .ToList();

                count = _storeContext.Products.Count();
            }
            else
            {
                string searchTerm = productParameters.SearchTerm.Trim().ToLower();

                productsSearched = _storeContext.Products
                                    .Where(pr => pr.Name.ToLower().Contains(searchTerm))
                                    .OrderBy(pr => pr.Name)
                                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                                    .Take(productParameters.PageSize)
                                    .Include(pr => pr.Brand)
                                    .Include(pr => pr.Characteristics)
                                    .ThenInclude(c => c.ProductCharacteristics)
                                    .Include(pr => pr.SubSubCategory)
                                    .ToList();

                count = _storeContext.Products
                        .Where(pr => pr.Name.ToLower().Contains(searchTerm))
                        .Count();

            }


            return new PagedList<Product>(productsSearched, count, productParameters.PageNumber, productParameters.PageSize);

        }


    }
}
