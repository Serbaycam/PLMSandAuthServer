using PLMS.Core.Entities;

namespace PLMS.Core.Entity
{
    public partial class SizeSet : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Size> Sizes { get; set;}

    }
}
