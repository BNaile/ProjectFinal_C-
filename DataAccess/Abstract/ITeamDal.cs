using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ITeamDal : IBaseRepository<Team>
    {
        List<TeamDto> GetTeamWithPositionCategories();
    }

}
