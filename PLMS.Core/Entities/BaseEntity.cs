namespace PLMS.Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedById { get; set; }
        public DateTime ?ModifiedDate { get; set; }
        public string ?ModifiedById { get; set; }

    }
}
