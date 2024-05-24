using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface IPhotoDal : IBaseRepository<Photo>
    {
        List<PhotoDto> GetPhotMeWithCategory();
    }

}
