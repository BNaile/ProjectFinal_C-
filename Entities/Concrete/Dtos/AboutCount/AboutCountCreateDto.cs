using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutCountCreateDto
    {
        public int Count { get; set; }
        public static AboutCount ToAboutCount(AboutCountCreateDto dto)
        {
            AboutCount aboutcount = new()
            {
               
                Count = dto.Count,
            };
            return aboutcount;

        }
    }
}
