
using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CallMeCreateDto
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ServiceCategoryName { get; set; }
        public static CallMe ToCallMe(CallMeCreateDto dto)
        {
           CallMe callMeCreate = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
               
            };
            return callMeCreate;
        }
    }
}
