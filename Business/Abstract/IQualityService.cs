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
    public interface IQualityService
    {
        IResult Add(QualityCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(QualityUpdateDto dto);
        IDataResult<List<Quality>> GetAll();
        IDataResult<Quality> GetById(int id);
    }
}
