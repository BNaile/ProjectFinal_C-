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
    public class QualityManager: IQualityService
    {
        private readonly IQualityDal _qualityDal;
        private readonly IValidator<Quality> _validator;
        public QualityManager(IQualityDal qualityDal, IValidator<Quality> validator)
        {
            _qualityDal = qualityDal;
            _validator = validator;
        }
        public IResult Add(QualityCreateDto dto)
        {
            var model = QualityCreateDto.ToQuality(dto);
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
            _qualityDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

    

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            entity.Deleted = id;
            _qualityDal.Delete(entity);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Quality>> GetAll()
        {
            var result = _qualityDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<Quality>>(result);
        }

        public IDataResult<Quality> GetById(int id)
        {
            var result = _qualityDal.GetById(id);
            return new SuccessDataResult<Quality>(result);
        }

        public IResult UpDate(QualityUpdateDto dto)
        {
            var model = QualityUpdateDto.ToQuality(dto);
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
            _qualityDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
           
        }

        
    }
}
