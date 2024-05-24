using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ServicePackageDescriptionUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ServicePackageId { get; set; }
        public static ServicePackageDescription ToService(ServicePackageDescriptionUpdateDto dto)
        {
            ServicePackageDescription service = new()
            {
                Id=dto.Id,
                Description = dto.Description,
                ServicePackageId = dto.ServicePackageId

            };
            return service;
        }
    }
}
