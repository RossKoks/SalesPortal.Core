using System;
using Domain.Extensions;
using System.Collections.Generic;

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
            return new Result<TResult>(result, result != null && !result.Equals(default(TResult)), messages);
        }

        public static Result<TResult> Wrap<TResult>(TResult value, Func<TResult, bool> predicate,
            params string[] messages)
        {
            return new Result<TResult>(value, value != null && !value.Equals(default(TResult)) && predicate(value), messages);
        }

        public static Result<TResult> WrapValue<TResult>(TResult result, params string[] messages) where TResult : struct
        {
            return new Result<TResult>(result, true, messages);
        }

        public static Result<T> Error(params string[] messages)
        {
            return new Result<T>(default(T), false, messages);
        }
    }

    public class Result<T, TResultType> : Result<T>
        where TResultType : struct, IComparable, IFormattable, IConvertible
    {
        private TResultType? _resultType;
        private string _result;

        public Result(T val, bool isSuccess, string result, params string[] messages)
            : base(val, isSuccess, messages)
        {
            _result = result;
        }

        public TResultType ResultType
        {
            get
            {
                if (!_resultType.HasValue)
                {
                    _resultType = _result.ToEnumByEnumMember<TResultType>();
                }

                return _resultType.Value;
            }
        }

        public static Result<TResult, TResultType> WrapDml<TResult>(Tuple<TResult,string> result, params string[] messages)
        {
            return new Result<TResult, TResultType>(result.Item1
                , result.Item1 != null && !result.Item1.Equals(default(TResult))
                , result.Item2
                , messages);
        }
    }
}
