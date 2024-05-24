using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ICallMeDal : IBaseRepository<CallMe>
    {
        List<CallMeDto> GetAllCallMeWithServices();
    }

}
