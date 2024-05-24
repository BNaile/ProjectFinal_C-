using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class IntroCat:BaseEntity
    {
        public string Icon { get; set; }
        public  string Title { get; set; }
        public  string Description { get; set; }
    }
}
