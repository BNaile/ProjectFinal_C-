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
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class IntroManager : IIntroService
    {
        private readonly IIntroDal _introDal;
        private readonly IValidator<Intro> _validator;
        public IntroManager(IIntroDal introDal, IValidator<Intro> validator)
        {
            _introDal = introDal;
            _validator = validator;
        }

        public IResult Add(IntroCreateDto dto, IFormFile photoUrl, string webRootpath)
        {

            var model = IntroCreateDto.ToIntro(dto);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootpath);
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
            _introDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);


        }

        

        public IResult Delete(int id)
        {

            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("İntro entry not found.");
            }

            var data = dataResult.Data;
            data.Deleted = id;

            _introDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<Intro>> GetAll()
        {

            var result = _introDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<Intro>>(result);

        }

        public IDataResult<Intro> GetById(int id)
        {


            var result = _introDal.GetById(id);
            return new SuccessDataResult<Intro>(result);


        }

        public IResult UpDate(IntroUpdateDto dto, IFormFile photoUrl, string webRootpath)
        {

            var model = IntroUpdateDto.ToIntro(dto);
            var value = GetById(dto.Id).Data;
            if (photoUrl == null)
            {
                model.PhotoUrl = value.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootpath); ;
            }
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
            _introDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }

        
    }
}
