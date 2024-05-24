using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class CallMeDal : BaseRepository<CallMe, ApplicationDbContext>, ICallMeDal
    {
        private readonly ApplicationDbContext _context;

        public CallMeDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CallMeDto> GetAllCallMeWithServices()
        {
           var result = from callMe in _context.CallMes
                        where callMe.Deleted == 0
                        join service in _context.ServicePackages
                        on callMe.ServiceID equals service.Id
                        where service.Deleted == 0
                        select new CallMeDto
                        {
                            Id = callMe.Id,
                            Description = callMe.Description,
                            Title = callMe.Title,
                            Phone = callMe.Phone,
                            Email= callMe.Email,
                            Name = callMe.Name,
                            ServiceCategoryName= service.Title
                         };

            return result.ToList();
        }

        //public List<ServicePackageDto> GetCallMeWithService()
        //{


        //var result = from callMe in _context.CallMes
        //                 where callMe.Deleted == 0
        //                 join callMeS in _context.ServicePackages
        //                 on callMe.ServiceID equals callMeS.Id
        //                 where callMeS.Deleted == 0
        //                 select new ServicePackageDto
        //                 {
        //                     Id = callMe.Id,
        //                     Description = callMe.Description,
        //                     Title = callMe.Title,
        //                     Price = callMe.
        //                 };
        //   return result.ToList();
        //}
    }
}
