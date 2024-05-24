using Business.Abstract;
using Business.BaseMessage;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IValidator<About> _validator;
        public AboutManager(IAboutDal aboutDal, IValidator<About> validator)
        {
            _aboutDal = aboutDal;
            _validator = validator;
        }

        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);
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
            _aboutDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IDataResult<List<About>> GetAll()
        {
            var result = _aboutDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<About>>(result);
        }

        public IDataResult<About> GetById(int id)
        {
            var result = _aboutDal.GetById(id);
            return new SuccessDataResult<About>(result);
        }

        public IResult UpDate(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);
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
            _aboutDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

     
    }

    

 


    
}
    


