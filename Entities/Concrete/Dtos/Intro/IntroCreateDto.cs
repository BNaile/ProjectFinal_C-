using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class IntroCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
        public static Intro ToIntro(IntroCreateDto dto)
        {
            Intro intro = new()
            {
               Title = dto.Title,
               Description = dto.Description,
               Name = dto.Name,
               PhotoUrl = dto.PhotoUrl,
               Surname = dto.Surname,
            };
            return intro;
        }
    }
}
