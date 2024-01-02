using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public class OrderItemRecipe:BaseEntity
    {
        public OrderItem OrderItem { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        

    }
}
