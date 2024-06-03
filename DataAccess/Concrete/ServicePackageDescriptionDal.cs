using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class ServicePackageDescriptionDal : BaseRepository<ServicePackageDescription, ApplicationDbContext>, IServicePackageDescriptionDal
    {
        private readonly ApplicationDbContext _context;

        public ServicePackageDescriptionDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ServicePackageDescriptionDto> GetServiceWithServicePackages()
        {
            var result = from ServicePackageDescription in _context.ServicePackageDescriptions
                         where ServicePackageDescription.Deleted == 0
                         join ServicePackage in _context.ServicePackages
                         on ServicePackageDescription.ServicePackageId equals ServicePackage.Id
                         where ServicePackage.Deleted == 0
                         select new ServicePackageDescriptionDto
                         {
                             İd= ServicePackage.Id,
                             ServicePackageId= ServicePackage.Id,
                             Description= ServicePackage.Description,   
                         };
            return result.ToList();
        } 
    }
}
