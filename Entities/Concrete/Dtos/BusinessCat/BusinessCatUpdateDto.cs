using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BusinessCatUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Points { get; set; }
        public static BusinessCat ToBusinessCat(BusinessCatUpdateDto dto)
        {
            BusinessCat businessCat = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                Points = dto.Points,
            };
            return businessCat;
            
        }
    }
}
