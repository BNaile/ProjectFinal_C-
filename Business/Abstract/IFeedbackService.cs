using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeedbackService
    {
        IResult Add(FeedbackCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(FeedbackUpdateDto dto);
        IDataResult<List<Feedback>> GetAll();
        IDataResult<Feedback> GetById(int id);
    }
}
