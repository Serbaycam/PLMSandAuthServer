using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class OrderItem:BaseEntity
    {
        public Order Order { get; set; }

        public Color Color { get; set; }    
        public SizeSet SizeSet { get; set; }
        public ICollection<OrderItemRecipe> OrderItemRecipes { get; set; }

        
    }
}
