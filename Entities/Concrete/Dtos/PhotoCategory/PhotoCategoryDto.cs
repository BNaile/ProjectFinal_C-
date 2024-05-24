using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PhotoCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public static List<PhotoCategoryDto> ToPhotoCategory(PhotoCategory photocategory)
        {
            PhotoCategoryDto dto = new PhotoCategoryDto()
            {
                Id = photocategory.Id,
                CategoryName = photocategory.CategoryName,
            };
            List<PhotoCategoryDto> dtoList = new List<PhotoCategoryDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
