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
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;
        private readonly IValidator<Position> _validator;
        public PositionManager(IPositionDal positionDal, IValidator<Position> validator)
        {
            _positionDal = positionDal;
            _validator = validator;
        }

        public IResult Add(PositionCreateDto dto)
        {

            var model = PositionCreateDto.ToPosition(dto);
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
            _positionDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);


        }

        public IResult Delete(int id)
        {

            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("CallMe entry not found.");
            }

            var data = dataResult.Data;
            data.Deleted = id;

            _positionDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<PositionDto>> GetAll()
        {

            var models = _positionDal.GetAll(x => x.Deleted == 0);

            List<PositionDto> positionDtos = new List<PositionDto>();

            foreach (var model in models)
            {
                PositionDto dto = new PositionDto()
                {
                    Id= model.Id,
                    Name= model.Name,
                };
                positionDtos.Add(dto);
            }
            return new SuccessDataResult<List<PositionDto>>(positionDtos);
        }

        public IDataResult<Position> GetById(int id)
        {


            var result = _positionDal.GetById(id);
            return new SuccessDataResult<Position>(result);


        }

        public IResult UpDate(PositionUpdateDto dto)
        {

            var model = PositionUpdateDto.ToPosition(dto);
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
            _positionDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }
    }
}
