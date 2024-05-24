using Business.Abstract;
using Business.BaseMessage;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class CallMeManager : ICallMeService
    {
        private readonly ICallMeDal _callMeDal;
        private readonly IValidator<CallMe> _validator;
        public CallMeManager(ICallMeDal callMeDal, IValidator<CallMe> validator)
        {
            _callMeDal = callMeDal;
            _validator = validator;
        }

        public IResult Add(CallMeCreateDto dto)
        {
            
                var model = CallMeCreateDto.ToCallMe(dto);
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
            _callMeDal.Add(model);
                return new SuccessResult(UIMessages.ADDED_MESSAGE);
            
           
        }

        public IResult Delete(int id)
        {
            
                var dataResult = GetById(id);
                if (dataResult.Data == null)
                {
                    return new ErrorResult("CallMe entry not found.");
                }

                var data = dataResult.Data;
                data.Deleted = id; 

                _callMeDal.Update(data);
                return new SuccessResult(UIMessages.Deleted_MESSAGE);
           
        }

        public IDataResult<List<CallMe>> GetAll()
        {
            
                var result = _callMeDal.GetAll(x => x.Deleted == 0);
                return new SuccessDataResult<List<CallMe>>(result);
           
        }

        public IDataResult<CallMe> GetById(int id)
        {
          
            
                var result = _callMeDal.GetById(id);
                return new SuccessDataResult<CallMe>(result);
            
          
        }

        public IResult UpDate(CallMeUpdateDto dto)
        {
            
                var model = CallMeUpdateDto.ToCallMe(dto);
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
                _callMeDal.Update(model);
                return new SuccessResult(UIMessages.UPDATE_MESSAGE);
           
        }

       
    }
}
