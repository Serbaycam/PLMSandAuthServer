using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class Size : BaseEntity
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int SizeSetId { get; set; }
        public SizeSet SizeSet { get; set; }
    }
}
