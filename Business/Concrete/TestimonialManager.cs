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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        private readonly IValidator<Testimonial> _validator;
        public TestimonialManager(ITestimonialDal testimonialDal, IValidator<Testimonial> validator)
        {
            _testimonialDal = testimonialDal;
            _validator = validator;
        }
        public IResult Add(TestimonialCreateDto dto)
        {
            var model = TestimonialCreateDto.ToTestimonial(dto);
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
            _testimonialDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            entity.Deleted = id;
            _testimonialDal.Delete(entity);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            var result = _testimonialDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<Testimonial>>(result);
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            var result = _testimonialDal.GetById(id);
            return new SuccessDataResult<Testimonial>(result);
        }

        public IResult UpDate(TestimonialUpdateDto dto)
        {
            var model = TestimonialUpdateDto.ToTestimonial(dto);
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
            _testimonialDal.Update(model); 
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
