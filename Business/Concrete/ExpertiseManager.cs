using Business.Abstract;
using Business.BaseMessage;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class ExpertiseManager : IExpertiseService
    {
        private readonly IExpertiseDal _expertiseDal;
        private readonly IValidator<Expertise> _validator;
        public ExpertiseManager(IExpertiseDal expertiseDal, IValidator<Expertise> validator)
        {
            _expertiseDal = expertiseDal;
            _validator = validator;
        }
        public IResult Add(ExpertiseCreateDto dto)
        {
            var model = ExpertiseCreateDto.ToExpertise(dto);
             var validator = _validator.Validate(model);
            string errorMessage = " ";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _expertiseDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {

            
            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("Expertise entry not found.");
            }

            var data = dataResult.Data;
            data.Deleted = id;

            _expertiseDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Expertise>> GetAll()
        {
            var result = _expertiseDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<Expertise>>(result);
        }

        public IDataResult<Expertise> GetById(int id)
        {
            var result = _expertiseDal.GetById(id);
            return new SuccessDataResult<Expertise>(result);
        }

        public IResult UpDate(ExpertiseUpdateDto dto)
        {
            var model = ExpertiseUpdateDto.ToExpertise(dto);
            var validator = _validator.Validate(model);
            string errorMessage = " ";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            model.LastUpdateDate = DateTime.Now;
            _expertiseDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
