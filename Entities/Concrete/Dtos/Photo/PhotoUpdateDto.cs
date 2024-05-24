using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PhotoUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PhotoCategoryId { get; set; }
        public static  Photo ToPhoto(PhotoUpdateDto dto)
        {
            Photo photo = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                PhotoCategoryId = dto.PhotoCategoryId,
            };
            return photo;
        }
    }
}
