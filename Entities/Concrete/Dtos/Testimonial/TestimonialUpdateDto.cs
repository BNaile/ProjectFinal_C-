using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TestimonialUpdateDto
    {
        public int Id { get; set; }
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public static Testimonial ToTestimonial(TestimonialUpdateDto dto)
        {
            Testimonial testimonal = new()
            {
                Id=dto.Id,
                UrlPhoto = dto.UrlPhoto,
                Name = dto.Name,
                Surname = dto.Surname,
                Description = dto.Description

            };
            return testimonal;
        }
    }
}
