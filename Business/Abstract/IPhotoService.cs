using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoService
    {
     
        IResult Add(PhotoCreateDto dto);
        IResult Delete(int id );
        IResult UpDate(PhotoUpdateDto dto);
        IDataResult<List<PhotoDto>> GetPhotMeWithCategory();
        IDataResult<Photo> GetById(int id);
    }
}
