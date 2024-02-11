namespace PLMS.Core.Entity
{
#nullable enable
    public abstract class BaseEntity
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedById { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedById { get; set; }
        public bool IsDeleted { get; set; }
        public string? IsDeletedById { get; set; }
        public DateTime? IsDeletedDate { get; set; }
        public bool IsDeactived { get; set; }
        public string? IsDeactivedById { get; set; }
        public DateTime? IsDeactivedDate { get; set; }


    }
}
