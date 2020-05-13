using System;
using api.Core.Models;

namespace api.Core.Extensions
{
    public static class HelperExtensions
    {
        public static Result<T> ToResult<T>(this T data)
        {
            return Result<T>.Success(data);
        }

        public static Result<T> ToResult<T>(this Error error)
        {
            return Result<T>.Failed(error);
        }
    }
}
