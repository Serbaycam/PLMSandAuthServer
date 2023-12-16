using PLMS.Core.Entities;

namespace PLMS.Core.Entity
{
    public partial class SizeSet : BaseEntity
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public ICollection<Size> Sizes { get; set; }

    }
}
