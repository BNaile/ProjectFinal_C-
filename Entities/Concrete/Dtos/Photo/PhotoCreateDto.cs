using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class PhotoCreateDto
    {
        public string Name { get; set; }
        public int PhotoCategoryId { get; set; }
        public static Photo ToPhoto(PhotoCreateDto dto)
        {
            Photo photo = new()
            {
                Name= dto.Name,
                PhotoCategoryId= dto.PhotoCategoryId,
            };
            return photo;
        }
    }
}
