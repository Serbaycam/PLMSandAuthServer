using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class ModelGroup : BaseEntity
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
