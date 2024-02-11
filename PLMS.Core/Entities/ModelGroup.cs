using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class ModelGroup : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
