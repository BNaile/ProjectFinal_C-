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
    public class ServicePackageDescriptionManager : IServicePackageDescription
    {
        private readonly IServicePackageDescriptionDal _servicePackageDescriptionDal;
        private readonly IValidator<ServicePackageDescription> _validator;
        public ServicePackageDescriptionManager(IServicePackageDescriptionDal servicePackageDescriptionDal, IValidator<ServicePackageDescription> validator)
        {
            _servicePackageDescriptionDal = servicePackageDescriptionDal;
            _validator = validator;
        }
        //public IResult Add(ServicePackageDescription entity)
        //{
        //    _servicePackageDescriptionDal.Add(entity);
        //    return new SuccessResult(UIMessages.ADDED_MESSAGE);
        //}

        public IResult Add(ServicePackageDescriptionCreateDto dto)
        {
            var model = ServicePackageDescriptionCreateDto.ToService(dto);
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
            _servicePackageDescriptionDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {

            var entity = GetById(id).Data;
            entity.Deleted = id;
            _servicePackageDescriptionDal.Delete(entity);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<ServicePackageDescriptionDto>> GetServiceWithServicePackages()
        {
            //var result = _servicePackageDescriptionDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<ServicePackageDescriptionDto>>(_servicePackageDescriptionDal.GetServiceWithServicePackages());
        }

        public IDataResult<ServicePackageDescription> GetById(int id)
        {
            var result = _servicePackageDescriptionDal.GetById(id);
            return new SuccessDataResult<ServicePackageDescription>(result);
        }

        public IResult UpDate(ServicePackageDescription entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _servicePackageDescriptionDal.Update(entity);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult UpDate(ServicePackageDescriptionUpdateDto dto)
        {
            var model = ServicePackageDescriptionUpdateDto.ToService(dto);
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
            _servicePackageDescriptionDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

      
    }
}
