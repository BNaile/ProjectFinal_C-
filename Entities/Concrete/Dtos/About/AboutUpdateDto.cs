using Entities.Concrete.TableModels;
namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }

        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new()
            {
                Id = dto.Id,
                ShortDescription = dto.ShortDescription,
            };
            return about;
        }
    }
}

