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
    public interface IPhotoService
    {
     
        IResult Add(PhotoCreateDto dto, IFormFile Name, string webRootpath);
        IResult Delete(int id );
        IResult UpDate(PhotoUpdateDto dto, IFormFile Name, string webRootpath);
        IDataResult<List<PhotoDto>> GetPhotMeWithCategory();
        IDataResult<Photo> GetById(int id);
    }
}
