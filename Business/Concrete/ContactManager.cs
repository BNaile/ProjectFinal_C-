using Business.Abstract;
using Business.BaseMessage;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {

        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _validator;
        public ContactManager(IContactDal contactDal, IValidator<Contact> validator)
        {
            _contactDal = contactDal;
            _validator = validator;
        }

        public IResult Add(ContactCreateDto dto)
        {

            var model = ContactCreateDto.ToContact(dto);
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
            _contactDal.Add(model);
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

            _contactDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<Contact>> GetAll()
        {

            var result = _contactDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<Contact>>(result);

        }

        public IDataResult<Contact> GetById(int id)
        {


            var result = _contactDal.GetById(id);
            return new SuccessDataResult<Contact>(result);


        }

        public IResult UpDate(ContactUpdateDto dto)
        {

            var model = ContactUpdateDto.ToContact(dto);
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
            _contactDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }

       
    }
}
