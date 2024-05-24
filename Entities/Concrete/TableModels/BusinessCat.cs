using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class BusinessCat:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Points { get; set; }
       
    }
}
