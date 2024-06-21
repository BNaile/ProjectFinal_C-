using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ExpertiseUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public static Expertise ToExpertise(ExpertiseUpdateDto dto)
        {
            Expertise expertise = new()
            {
                Id = dto.Id,
                Description = dto.Description,
                
            };

            return expertise;
        }
     
    }
}
