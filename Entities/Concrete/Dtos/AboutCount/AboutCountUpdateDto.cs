using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class AboutCountUpdateDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
       
        public static AboutCount ToAboutCount(AboutCountUpdateDto dto)
        {
            AboutCount category = new()
            {
                Id = dto.Id,
                Count = dto.Count,
               
            };
            return category;
        }
    }
}
