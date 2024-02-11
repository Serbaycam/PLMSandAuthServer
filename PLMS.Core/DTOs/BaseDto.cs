namespace PLMS.Core.DTOs
{
#nullable enable
    public class BaseDto
    {
        public int? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedById { get; set; }

    }
}
