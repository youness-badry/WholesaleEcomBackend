using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;

namespace WholesaleEcomBackend.Data.Interfaces
{
    public interface IBrandRepo { 
        
        Brand CreateBrand(Brand brand);
        PagedList<Brand> GetBrandsWithPaging(BrandParameters brandParameters);
        Brand GetBrandById(int id);
        


    }
}
