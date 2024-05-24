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
    public interface ICallMeService
    {
        IResult Add(CallMeCreateDto dto);
        IResult Delete( int id);
        IResult UpDate(CallMeUpdateDto dto);
        IDataResult<List<CallMe>> GetAll();
        IDataResult<CallMe> GetById(int id);
    }
}
