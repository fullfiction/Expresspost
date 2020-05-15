using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Core.Models;
using api.Infrastructure.ActionResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Extensions
{
    public static class HelperExtensions
    {
        public static IActionResult AsApiResult<T>(this List<T> data, int count)
        {
            return new ApiActionResult<List<T>>(Result<List<T>>.Success(data), count);
        }

        public static IActionResult AsApiResult<T>(this Result<T> result)
        {
            return new ApiActionResult<T>(result);
        }

        public static IActionResult AsApiResult<T>(this T data)
        {
            if (data == null)
                return new ApiActionResult<T>(Result<T>.Failed(ErrorDescriber.DataNotFound()));
            return new ApiActionResult<T>(Result<T>.Success(data));
        }
    }
}
