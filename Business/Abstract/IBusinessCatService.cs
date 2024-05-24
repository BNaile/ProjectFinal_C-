using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IBusinessCatService
    {
        IResult Add(BusinessCatCreateDto dto);
        IResult Delete(int id);
        IResult UpDate (BusinessCatUpdateDto dto);
        IDataResult <List<BusinessCat>> GetAll();
        IDataResult <BusinessCat> GetById(int id);
    }
}
