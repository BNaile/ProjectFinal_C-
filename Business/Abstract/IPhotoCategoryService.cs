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
    public interface IPhotoCategoryService
    {
        IResult Add(PhotoCategoryCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(PhotoCategoryUpdateDto dto);
        IDataResult<List<PhotoCategoryDto>> GetAll();
        IDataResult<PhotoCategory> GetById(int id);
    }
}
