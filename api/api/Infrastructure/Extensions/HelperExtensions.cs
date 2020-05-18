using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using api.Core.Models;
using api.Infrastructure.ActionResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Extensions
{
    public static class HelperExtensions
    {
        public static ActionResult AsApiResult<T>(this List<T> data, int count)
        {
            return new ApiActionResult<List<T>>(Result<List<T>>.Success(data), count);
        }

        public static ActionResult AsApiResult<T>(this Result<T> result)
        {
            return new ApiActionResult<T>(result);
        }

        public static ActionResult AsApiResult<T>(this T data)
        {
            if (data == null)
                return new ApiActionResult<T>(Result<T>.Failed(ErrorDescriber.DataNotFound()));
            return new ApiActionResult<T>(Result<T>.Success(data));
        }

        public static long GetSub(this ClaimsPrincipal principal)
        {
            var subClaimValue = principal.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            return Convert.ToInt64(subClaimValue);
        }
    }
}
