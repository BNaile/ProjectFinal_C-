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

    public class PhotoManager : IPhotoService
    {
        private readonly IPhotoDal _photoDal;
        private readonly IValidator<Photo> _validator;
        public PhotoManager(IPhotoDal photoDal, IValidator<Photo> validator)
        {
            _photoDal = photoDal;
            _validator = validator;
        }

        public IResult Add(PhotoCreateDto dto, IFormFile Name, string webRootpath)
        {

            var model = PhotoCreateDto.ToPhoto(dto);
            model.Name = PictureHelper.UploadImage(Name, webRootpath);
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
            _photoDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);


        }

        public IResult Delete(int id)
        {

            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("Photo entry not found.");
            }

            var data = dataResult.Data;
            data.Deleted =id;

            _photoDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<PhotoDto>> GetPhotMeWithCategory()
        {
           
            return new SuccessDataResult<List<PhotoDto>>(_photoDal.GetPhotMeWithCategory());

        }

        public IDataResult<Photo> GetById(int id)
        {


            var result = _photoDal.GetById(id);
            return new SuccessDataResult<Photo>(result);


        }

        public IResult UpDate(PhotoUpdateDto dto, IFormFile Name, string webRootpath)
        {
            var model = PhotoUpdateDto.ToPhoto(dto);
            var value=GetById(dto.Id).Data;
            if (Name == null)
            {
                model.Name = value.Name;
            }
            else
            {
                model.Name = PictureHelper.UploadImage(Name, webRootpath); 
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
            _photoDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }

       
    }
}
