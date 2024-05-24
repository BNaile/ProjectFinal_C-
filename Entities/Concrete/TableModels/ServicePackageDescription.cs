using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class ServicePackageDescription:BaseEntity
    {
        public string Description { get; set; }
        public int ServicePackageId { get; set; }
        public virtual ServicePackage ServicePackage { get; set; }

    }
}
