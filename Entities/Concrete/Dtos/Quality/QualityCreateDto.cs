using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class QualityCreateDto
    {
        public string Description { get; set; }
        public static Quality ToQuality(QualityCreateDto dto)
        {
            Quality quality = new()
            {
                Description = dto.Description,
            };
            return quality;
        }
    }
}
