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
    public interface IIntroService
    {
        IResult Add(IntroCreateDto dto, IFormFile photoUrl, string webRootpath);
        IResult Delete(int id);
        IResult UpDate(IntroUpdateDto dto, IFormFile photoUrl, string webRootpath);
        IDataResult<List<Intro>> GetAll();
        IDataResult<Intro> GetById(int id);
    }
}
