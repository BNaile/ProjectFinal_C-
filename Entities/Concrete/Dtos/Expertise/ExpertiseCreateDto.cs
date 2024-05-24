using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ExpertiseCreateDto
    {
        
        public string Description { get; set; }
        public static Expertise ToExpertise(ExpertiseCreateDto dto)
        {
            Expertise expertise = new()
            {
                Description = dto.Description,
            };

            return expertise;
        }
    }
}
