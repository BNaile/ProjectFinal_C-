using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PhotoCategoryUpdateDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string ImageName { get; set; }
        public static PhotoCategory ToPhoto(PhotoCategoryUpdateDto dto)
        {
            PhotoCategory photoCategory = new()
            {
                Id=dto.Id,
                CategoryName = dto.CategoryName,
            };
            return photoCategory;
        }
    }
}
