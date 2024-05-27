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
    public interface IServicePackage
    {
        IResult Add(ServicePackageCreateDto dto, IFormFile photoUrl, string webRootpath);
        IResult Delete(int id);
        IResult UpDate(ServicePackageUpdateDto dto, IFormFile photoUrl, string webRootpath);
        IDataResult<List<ServicePackage>> GetAll();
        IDataResult<ServicePackage> GetById(int id);
    }
}
