using Core.Result.Abstract;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add (AboutCreateDto dto);
        IResult UpDate(AboutUpdateDto dto);
        IDataResult <List<About>> GetAll();
        IDataResult <About> GetById(int id);
    }
}
