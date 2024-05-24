using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ServicePackageDescriptionCreateDto
    {
        public string Description { get; set; }
        public int ServicePackageId { get; set; }
       
        public static ServicePackageDescription ToService(ServicePackageDescriptionCreateDto dto)
        {
            ServicePackageDescription service = new()
            {
                Description = dto.Description,
                ServicePackageId = dto.ServicePackageId,
               
         
            };
            return service;
        }
    }
}
