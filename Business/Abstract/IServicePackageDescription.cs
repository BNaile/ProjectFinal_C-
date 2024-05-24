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
    public interface IServicePackageDescription
    {
        IResult Add(ServicePackageDescriptionCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(ServicePackageDescriptionUpdateDto dto);
        IDataResult<List<ServicePackageDescription>> GetAll();
        IDataResult<ServicePackageDescription> GetById(int id);
    }
}
