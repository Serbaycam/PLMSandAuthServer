using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class Size : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SizeSet SizeSet { get; set; }
    }
}
