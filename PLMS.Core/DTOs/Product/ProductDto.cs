using PLMS.Core.Entity;

namespace PLMS.Core.DTOs.Product
{
    public class ProductDto : BaseEntity
    {
        public required string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
