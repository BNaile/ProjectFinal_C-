using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IResult Add(TestimonialCreateDto dto, IFormFile UrlPhoto, string webRootpath);
        IResult Delete(int id);
        IResult UpDate(TestimonialUpdateDto dto, IFormFile UrlPhoto, string webRootpath);
        IDataResult<List<Testimonial>> GetAll();
        IDataResult<Testimonial> GetById(int id);
    }
}
