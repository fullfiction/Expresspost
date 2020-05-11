using System;

namespace api.Core.Models
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Succeed { get; set; }
        public Error Error { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Succeed = true,
                Data = data,
                Error = null
            };
        }

        public static Result<T> Failed(Error error)
        {
            return new Result<T>
            {
                Succeed = false,
                Data = default(T),
                Error = error
            };
        }
    }
}
