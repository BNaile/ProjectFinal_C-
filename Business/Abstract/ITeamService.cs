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
    public interface ITeamService
    {
        IResult Add(TeamCreateDto dto, IFormFile PhotoUrl, string webRootpath);
        IResult Delete(int id);
        IResult UpDate(TeamUpdateDto dto, IFormFile PhotoUrl, string webRootpath);
        IDataResult<List<TeamDto>> GetTeamWithPositionCategories();
        IDataResult<Team> GetById(int id);
    }
}
