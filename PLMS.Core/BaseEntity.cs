namespace PLMS.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

    }
}
