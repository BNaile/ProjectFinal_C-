using Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }
        public DataResult(T data, bool IsSuccess) : base(IsSuccess)
        {
            Data = data;
        }

        public DataResult(T data,string message, bool IsSuccess) : base(message, IsSuccess)
        {
            Data = data;
        }
    }
}
