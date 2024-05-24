using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class ServicePackage:BaseEntity
    {
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ServicePackageDescriptionId { get; set; }
        public List<ServicePackageDescription> ServicePackageDescription { get; set; }
        public ServicePackage()
        {
            ServicePackageDescription = new List<ServicePackageDescription>();
        }
    }
}
