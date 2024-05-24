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
    public class PhotoCategoryManager : IPhotoCategoryService
    {
        public readonly IPhotoCategoryDal _photCategoryDal;
        private readonly IValidator<PhotoCategory> _validator;
        public PhotoCategoryManager(IPhotoCategoryDal photCategoryDal, IValidator<PhotoCategory> validator)
        {
            _photCategoryDal = photCategoryDal;
            _validator = validator;
        }

        public IResult Add(PhotoCategoryCreateDto dto)
        {
            var model = PhotoCategoryCreateDto.ToPhoto(dto);
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
            _photCategoryDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            entity.Deleted = id;
            _photCategoryDal.Update(entity);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }
        public IDataResult<List<PhotoCategoryDto>> GetAll()
        {
                var result = _photCategoryDal.GetAll(x => x.Deleted == 0);
            List<PhotoCategoryDto> aboutDtos = new List<PhotoCategoryDto>();

            foreach(var item in result)
            {
                PhotoCategoryDto dto= new PhotoCategoryDto()
                {
                    Id = item.Id,
                    CategoryName = item.CategoryName,
                };
                aboutDtos.Add(dto);
            }
            return new SuccessDataResult<List<PhotoCategoryDto>>(aboutDtos);
        }

        public IDataResult<PhotoCategory> GetById(int id)
        {
            var result = _photCategoryDal.GetById(id);
            return new SuccessDataResult<PhotoCategory>(result);
        }

       

        public IResult UpDate(PhotoCategoryUpdateDto dto)
        {
            var model = PhotoCategoryUpdateDto.ToPhoto(dto);
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
            _photCategoryDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
