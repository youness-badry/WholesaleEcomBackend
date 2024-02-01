using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WholesaleEcomBackend.Data
{
    public class BrandRepo : IBrandRepo
    {
        private readonly StoreContext _storeContext;
        public BrandRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Brand GetBrandById(int id)
        {
            return _storeContext.Brands.Find(id);
        }

        public PagedList<Brand> GetBrandsWithPaging(BrandParameters brandParameters)
        {
            var items = _storeContext.Brands
                .OrderBy(br => br.Name)
                .Skip((brandParameters.PageNumber - 1) * brandParameters.PageSize)
                .Take(brandParameters.PageSize)
                .ToList();

            var count = _storeContext.Brands.Count();

            return new PagedList<Brand>(items, count, brandParameters.PageNumber, brandParameters.PageSize);
        }

        public Brand CreateBrand(Brand brand)
        {
            _storeContext.Brands.Add(brand);
            _storeContext.SaveChanges();
            return brand;
        }
    }
}
