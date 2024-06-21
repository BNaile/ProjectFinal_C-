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
    public class ServicePackageManager : IServicePackage
    {
        private readonly IServicePackageDal _servicePackageDal;
        private readonly IValidator<ServicePackage> _validator;
        public ServicePackageManager(IServicePackageDal servicePackageDal, IValidator<ServicePackage> validator)
        {
            _servicePackageDal = servicePackageDal;
            _validator = validator;
        }

        public IResult Add(ServicePackageCreateDto dto, IFormFile photoUrl, string webRootpath)
        {

            var model = ServicePackageCreateDto.ToService(dto);
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
            _servicePackageDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);


        }

      

        public IResult Delete(int id)
        {

            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("ServicePackage entry not found.");
            }

            var data = dataResult.Data;
            data.Deleted = id;

            _servicePackageDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<ServicePackage>> GetAll()
        {

            var result = _servicePackageDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<ServicePackage>>(result);

        }

        public IDataResult<ServicePackage> GetById(int id)
        {
            var result = _servicePackageDal.GetById(id);
            return new SuccessDataResult<ServicePackage>(result);
        }
        public IResult UpDate(ServicePackageUpdateDto dto, IFormFile photoUrl, string webRootpath)
        {
            var model = ServicePackageUpdateDto.ToService(dto);
            var value=GetById(dto.Id).Data;
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
            _servicePackageDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

    }
}
