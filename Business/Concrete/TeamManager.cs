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
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;
        private readonly IValidator<Team> _validator;
        public TeamManager(ITeamDal teamDal, IValidator<Team> validator)
        {
            _teamDal = teamDal;
            _validator = validator;
        }

        public IResult Add(TeamCreateDto dto)
        {

            var model = TeamCreateDto.ToTeam(dto);
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
            _teamDal.Add(model);
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

            _teamDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<TeamDto>> GetTeamWithPositionCategories()
        {

            //var result = _teamDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<TeamDto>>(_teamDal.GetTeamWithPositionCategories());

        }

        public IDataResult<Team> GetById(int id)
        {
            var result = _teamDal.GetById(id);
            return new SuccessDataResult<Team>(result);
        }

        public IResult UpDate(TeamUpdateDto dto)
        {

            var model = TeamUpdateDto.ToTeam(dto);
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
            _teamDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }
    }
}
