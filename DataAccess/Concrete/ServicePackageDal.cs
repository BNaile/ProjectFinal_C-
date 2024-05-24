using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ServicePackageDal : BaseRepository<ServicePackage, ApplicationDbContext>, IServicePackageDal
    {
    
    }

}
