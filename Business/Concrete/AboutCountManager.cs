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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutCountManager : IAboutCountService
    {
        private readonly IAboutCountDal _aboutCountDal;
        private readonly IValidator<AboutCount> _validator;
        public AboutCountManager(IAboutCountDal aboutCountDal, IValidator<AboutCount> validator)
        {
            _aboutCountDal = aboutCountDal;
            _validator = validator;
        }

        public IResult Add(AboutCountCreateDto dto)
        {
            var model = AboutCountCreateDto.ToAboutCount(dto);
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
            _aboutCountDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        
        
            public IResult Delete(int id)
            {
                var dataResult = GetById(id);
                if (dataResult.Data == null)
                {
                    return new ErrorResult("About Count not found.");
                }

                var data = dataResult.Data;
                data.Deleted = id;

               _aboutCountDal.Delete(data);
                return new SuccessResult(UIMessages.Deleted_MESSAGE);


            }
        

        public IDataResult<List<AboutCount>> GetAll()
        {
            var result = _aboutCountDal.GetAll(x=>x.Deleted == 0);
            return new SuccessDataResult<List<AboutCount>>(result);
        }

        public IDataResult<AboutCount> GetById(int id)
        {
            var result = _aboutCountDal.GetById(id);
            return new SuccessDataResult<AboutCount>(result);
        }

        public IResult UpDate(AboutCountUpdateDto dto)
        {
            var model = AboutCountUpdateDto.ToAboutCount(dto);
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
            _aboutCountDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

    }
}
