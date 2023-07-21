using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using SwaggerAPI.Helper;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpAccessor;
        protected ActionResult GetInvalidModelResponse(string errorCode, [CallerMemberName] string callerName = null, [CallerLineNumber] int callerLineNo = 0, string errDetail = "")
        {
            var parameter = JsonConvert.SerializeObject(ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList());
            return BadRequest(AppErrorType.InvalidInputDataFormat.GetErrorResponse(errorCode, parameter: parameter, callerName: callerName, callerLineNo: callerLineNo, errDetail: errDetail));
        }

        protected ActionResult GetResponse<TData>(BaseResponse<TData> response)
        {

            if (response.ResponseMessage == AppErrorType.DataNotFound.GetDescription())
            {
                return StatusCode((int)HttpStatusCode.NotFound, response.Error);
            }
            if (response.ResponseMessage == AppErrorType.InvalidInputDataFormat.GetDescription())
            {
                return StatusCode((int)HttpStatusCode.BadRequest, response.Error);
            }
            else if (!response.Result)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response.Error);
            }
            else if (response.Data == null)
            {
                return StatusCode((int)HttpStatusCode.NoContent, null);
            }

            return Ok(response);
        }

        protected ActionResult GetExceptionResponse(string errorCode, Exception ex, [CallerMemberName] string callerName = null, [CallerLineNumber] int callerLineNo = 0)
        {
            var msg = AppErrorType.InternalServiceError.GetDescription();
            return StatusCode((int)HttpStatusCode.InternalServerError, AppErrorType.InternalServiceError.GetErrorResponse(errorCode, ex.Message, callerName: callerName, callerLineNo: callerLineNo));
        }
    }
}
