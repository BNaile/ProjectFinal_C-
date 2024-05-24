using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PhotoCategoryId { get; set; }

        public static List<PhotoDto> ToPhotoCategory(Photo photo)
        {
            PhotoDto dto = new PhotoDto()
            {
                Id = photo.Id,
                Name = photo.Name,
                PhotoCategoryId = photo.PhotoCategoryId
            };
            List<PhotoDto> dtoList = new List<PhotoDto>();
            dtoList.Add(dto);
            return dtoList;
        }

    }
}
