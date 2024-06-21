using Business.Abstract;
using Business.BaseMessage;
using Core.Extentions;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class FeedbackManager : IFeedbackService
    {
        private readonly IFeedbackDal _feedbackDal;
        private readonly IValidator<Feedback> _validator;

        public FeedbackManager(IFeedbackDal feedbackDal, IValidator<Feedback> validator)
        {
            _feedbackDal = feedbackDal;
            _validator = validator;
        }
        public IResult Add(FeedbackCreateDto dto)
        {
           
            var model = FeedbackCreateDto.ToFeedback(dto);
          
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
            _feedbackDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);  
        }

        

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            entity.Deleted = id;
            _feedbackDal.Delete(entity);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Feedback>> GetAll()
        {
            var result = _feedbackDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<Feedback>>(result);
        }

        public IDataResult<Feedback> GetById(int id)
        {
            var result = _feedbackDal.GetById(id);
            return new SuccessDataResult<Feedback>(result);
        }

        public IResult UpDate(FeedbackUpdateDto dto)
        {
            var model = FeedbackUpdateDto.ToFeedback(dto);
          //var value =GetById(dto.Id).Data; 
           
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
            _feedbackDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        
    }
}
