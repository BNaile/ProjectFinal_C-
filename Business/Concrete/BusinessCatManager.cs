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
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class BusinessCatManager : IBusinessCatService
    {
      
        private readonly IBusinessCatDal _businessCatDal;
        private readonly IValidator<BusinessCat> _validator;

        public BusinessCatManager(IBusinessCatDal businessCatDal, IValidator<BusinessCat> validator)
        {
            _businessCatDal = businessCatDal;
            _validator = validator;
        }

        public IResult Add(BusinessCatCreateDto dto)
        {

            var model = BusinessCatCreateDto.ToBusinessCat(dto);
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
            _businessCatDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);

        }

        public IResult Delete(int id)
        {
            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("Business category not found.");
            }

            var data = dataResult.Data;
            data.Deleted = id;

            _businessCatDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<BusinessCat>> GetAll()
        {
            
                var result = _businessCatDal.GetAll(x => x.Deleted == 0);
                return new SuccessDataResult<List<BusinessCat>>(result);
            
        }

        public IDataResult<BusinessCat> GetById(int id)
        {
            
                var result = _businessCatDal.GetById(id);
                return new SuccessDataResult<BusinessCat>(result);
              
        }

        public IResult UpDate(BusinessCatUpdateDto dto)
        {
            var model = BusinessCatUpdateDto.ToBusinessCat(dto);
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
            _businessCatDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}

