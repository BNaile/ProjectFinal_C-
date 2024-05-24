using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public static Contact ToContact(ContactUpdateDto dto)
        {
            Contact contact = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Message = dto.Message,
            };
            return contact;


        }
    }
}
