using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPortal.Core.Models
{
    public class Result<T>
    {
        public T Value { get; }

        public bool IsSuccess { get; }

        public IEnumerable<string> Messages { get; }

        public Result(T val, bool isSuccess, params string[] messages)
        {
            this.Value = val;
            this.IsSuccess = isSuccess;
            this.Messages = messages;
        }

        public static Result<TResult> Wrap<TResult>(TResult result, params string[] messages) where TResult : class
        {
            return new Result<TResult>(result, result != null, messages);
        }

        public static Result<TResult> WrapValue<TResult>(TResult result, params string[] messages) where TResult : struct
        {
            return new Result<TResult>(result, true, messages);
        }

    }
}
