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

            // To change with .FirstOrDefault( condition..) Directly !!!!

        }

        public Product CreateProduct(Product product)
        {
            _storeContext.Products.Add(product);
            _storeContext.SaveChanges();
            var productCreated = GetProductById(product.Id);
            productCreated.Name = $"{product.Brand.Name} {product.Reference}";
            _storeContext.SaveChanges();
            return product;
        }

        public PagedList<Product> SearchProductsWithPaging(ProductParameters productParameters)
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

        public PagedList<Product> GetProductsBySubsubcategoryIdWithPagingAndFilters(int subsubcategoryId, ProductParameters productParameters)
        {
            var products = _storeContext.Products
                           .Where(p => p.SubSubCategoryId == subsubcategoryId);

            if (productParameters.MinPrice != null)
            {
                products = products.Where(p => p.Price >= productParameters.MinPrice && p.Price <= productParameters.MaxPrice);

            }

             if (productParameters.Brands != null)
            {
                string[] brandsIds = productParameters.Brands.Split('_');
                int[] brandsIdsNumeric = brandsIds.Select(id => int.Parse(id)).ToArray();
                
                products = products.Where(p => brandsIdsNumeric.Contains(p.BrandId));
            }

            if (productParameters.CharacteristicValues != null)
            {
                foreach(var characteristicValue in productParameters.CharacteristicValues)
                {
                    var characteristicName = characteristicValue.Key;
                    string[] valuesSelected = characteristicValue.Value.Split('_');


                    var productsIdsToKeep = (products.SelectMany(p => p.ProductCharacteristics)
                                            .Where(pch => pch.Characteristic.Name == characteristicName
                                                             && valuesSelected.Contains(pch.CharacteristicValue))
                                            .Select(pch => pch.ProductId)).ToList();

                    products = products.Where(p => productsIdsToKeep.Contains(p.Id));

                }

            }

            products = products.Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                        .Take(productParameters.PageSize)
                        .Include(pr => pr.Brand)
                        .Include(pr => pr.Characteristics)
                        .ThenInclude(c => c.ProductCharacteristics)
                        .Include(pr => pr.SubSubCategory);


            var listProducts = products.ToList();

            var count = products.Count();

            return new PagedList<Product>(listProducts, count, productParameters.PageNumber, productParameters.PageSize);

        }

        public List<Product> GetAllProductsBySubsubcategoryId(int subsubcategoryId, ProductParameters productParameters)
        {
            var products = _storeContext.Products
                            .Where(p => p.SubSubCategoryId == subsubcategoryId)
                            .Include(pr => pr.Brand)
                            .Include(pr => pr.Characteristics)
                            .ThenInclude(c => c.ProductCharacteristics)
                            .Include(pr => pr.SubSubCategory)
                            .ToList();

            return products;

        }

    }
}
