using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class Order:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? PlanningDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public Model Model { get; set; }
        ICollection<OrderItem> Items { get; set;}

    }
}
