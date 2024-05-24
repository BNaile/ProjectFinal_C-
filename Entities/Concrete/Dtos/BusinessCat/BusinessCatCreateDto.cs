using Entities.Concrete.Dto;
using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BusinessCatCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Points { get; set; }

        public static BusinessCat ToBusinessCat(BusinessCatCreateDto dto)
        {
            BusinessCat businessCat = new ()
            {
                Title = dto.Title,
                Description = dto.Description,
                Points = dto.Points,
            };
            return businessCat;
        }
    }
}
