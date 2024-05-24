using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class PhotoCategory:BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Photo> Photo { get; set; }
        public PhotoCategory()
        {
            Photo = new List<Photo>();
        }
    }
}
