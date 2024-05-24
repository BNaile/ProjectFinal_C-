using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class IntroUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
        public static Intro  ToIntro(IntroUpdateDto dto)
        {
            Intro intro = new()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Name = dto.Name,
                Surname = dto.Surname,
                PhotoUrl = dto.PhotoUrl,
            };
            return intro;
           
        }
    }
}
