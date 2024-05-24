using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class CallMeInterested:BaseEntity
    {
        public string Details { get; set; }
        public int CallMeId  { get; set; }
        public virtual CallMe CallMe { get; set; }
    }
}
