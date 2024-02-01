using WholesaleEcomBackend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.ReadDtos
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string StockStatus { get; set; }
        public string PictureUrl { get; set; }
        public string BrandName { get; set; }
        public SubSubCategoryReadDto SubSubCategory { get; set; }
        public List<ProductCharacteristicReadDto> ProductCharacteristics { get; set; }
    }
}
