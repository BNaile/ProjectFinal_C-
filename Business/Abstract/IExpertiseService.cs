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
    public interface IExpertiseService
    {

        IResult Add(ExpertiseCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(ExpertiseUpdateDto dto);
        IDataResult<List<Expertise>> GetAll();
        IDataResult<Expertise> GetById(int id);
    }
}
