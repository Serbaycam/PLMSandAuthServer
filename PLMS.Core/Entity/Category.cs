namespace PLMS.Core.Entity
{
    public class Category:BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Product> ?Products { get; set; }
    }
}
