using System.Collections;
using System.Threading.Tasks;
using api.Core.Models;
using api.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.ActionResults
{
    public class ApiActionResult<T> : ActionResult
    {
        private readonly Result<T> _result;
        private readonly int _count;

        public ApiActionResult(Result<T> result, int count = 0)
        {
            this._result = result;
            this._count = count;
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (_result.Data is IList && _result.Data.GetType().IsGenericType)
            {
                context.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
                context.HttpContext.Response.Headers.Add("X-Total-Count", _count.ToString());
            }

            return new OkObjectResult(new ResultModel<T>
            {
                Data = _result.Data,
                Error = _result.Error?.Message,
                Succeed = _result.Succeed

            }).ExecuteResultAsync(context);
        }
    }
}
