using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TestimonialCreateDto
    {
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public static Testimonial ToTestimonial(TestimonialCreateDto dto)
        {
            Testimonial testimonal = new()
            {
                UrlPhoto=dto.UrlPhoto,
                Name = dto.Name,
                Surname = dto.Surname,
                Description = dto.Description

            };
            return testimonal;
        }
    }
}
