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
    public class IntroCatManager : IIntroCatService
    {
        private readonly IIntroCatDal _introCatDal;
        private readonly IValidator<IntroCat> _validator;
        public IntroCatManager(IIntroCatDal introCatDal, IValidator<IntroCat> validator)
        {
            _introCatDal = introCatDal;
            _validator = validator;
        }
       

        public IResult Add(IntroCatCreateDto dto)
        {

            var model = IntroCatCreateDto.ToIntroCat(dto);
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
            _introCatDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            entity.Deleted = id;
            _introCatDal.Delete(entity);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<IntroCat>> GetAll()
        {
            var result = _introCatDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<IntroCat>>(result);
        }

        public IDataResult<IntroCat> GetById(int id)
        {
            var result = _introCatDal.GetById(id);
            return new SuccessDataResult<IntroCat>(result);
        }

        

        public IResult UpDate(IntroCatUpdateDto dto)
        {
            var model = IntroCatUpdateDto.ToIntroCat(dto);
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
            _introCatDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
