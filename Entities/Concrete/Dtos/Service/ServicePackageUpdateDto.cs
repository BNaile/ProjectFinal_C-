using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ServicePackageUpdateDto
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public static ServicePackage ToService(ServicePackageUpdateDto dto)
        {
            ServicePackage service = new()
            {
                Id= dto.Id,
                PhotoUrl= dto.PhotoUrl,
                Title= dto.Title,
                Description= dto.Description,
                Price= dto.Price,

            };
            return service;
        }
    }
}
