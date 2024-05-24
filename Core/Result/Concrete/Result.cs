using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class Result : IResult
    {
        public Result(bool IsSuccess)
        {
            this.IsSuccess = IsSuccess;
        }
        public Result(string message,bool IsSuccess):this(IsSuccess)
        {
            Message = message;
        }
        public string Message { get; }

        public bool IsSuccess { get; }
    }
}
