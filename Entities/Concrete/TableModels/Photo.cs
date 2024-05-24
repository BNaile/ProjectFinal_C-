using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Photo:BaseEntity
    {
        public string  Name { get; set; }
        public int PhotoCategoryId { get; set; }
        public virtual PhotoCategory PhotoCategory { get; set; }
    }
}
