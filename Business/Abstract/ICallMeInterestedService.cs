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
    public interface ICallMeInterestedService
    {
        IResult Add(CallMeInterestedCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(CallMeInterestedUpdateDto dto);
        IDataResult<List<CallMeInterested>> GetAll();
        IDataResult<CallMeInterested> GetById(int id);
    }
}
