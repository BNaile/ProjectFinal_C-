using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PhotoCategoryCreateDto
    {
        public string CategoryName { get; set; }

        public static PhotoCategory ToPhoto(PhotoCategoryCreateDto dto)
        {
            PhotoCategory photoCategory = new()
            {
                CategoryName = dto.CategoryName,
            };
            return photoCategory;
        }
    }
}
