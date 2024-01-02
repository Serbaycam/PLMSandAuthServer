using PLMS.Core.Entity;

namespace PLMS.Core.Entities
{
    public partial class Model:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ModelGroup ModelGroup { get; set; }
    }
}
