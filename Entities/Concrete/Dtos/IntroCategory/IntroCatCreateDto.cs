using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class IntroCatCreateDto
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public static IntroCat ToIntroCat(IntroCatCreateDto dto)
        {
            IntroCat introcat = new()
            {
                Icon = dto.Icon,
                Title = dto.Title,
                Description = dto.Description,
           
            };
            return introcat;
        }
    }
}
