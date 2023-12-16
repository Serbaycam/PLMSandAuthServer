using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class Model:BaseEntity
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ModelInventoryId { get; set; }
        public ModelGroup ModelGroup { get; set; }
    }
}
