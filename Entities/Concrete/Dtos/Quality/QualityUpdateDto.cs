using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class QualityUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public static Quality ToQuality(QualityUpdateDto dto)
        {
            Quality quality = new()
            {
                Id=dto.Id,
                Description = dto.Description,
            };
            return quality;
        }
    }
}
