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
    public interface IIntroCatService
    {
        IResult Add(IntroCatCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(IntroCatUpdateDto dto);
        IDataResult<List<IntroCat>> GetAll();
        IDataResult<IntroCat> GetById(int id);
    }
}
