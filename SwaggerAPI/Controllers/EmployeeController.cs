using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using SwaggerAPI.Data;
using SwaggerAPI.Models;
using SwaggerAPI.Service;
using SwaggerAPI.Service.Employee;

namespace SwaggerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : BaseController
{
    private readonly IEmployee _service;
    public EmployeeController(IEmployee service)
    {
        this._service = service;
    }

    [HttpGet("count")]
    public ActionResult<int> GetInfectedCount()
    {
        return 0;
    }
    
    /// <summary>
    /// ทดสอบ API
    /// </summary>
    /// <remarks>
    /// <b>Error Code</b>
    /// <para><b>TESTAPI</b> : Exception</para>
    /// </remarks>
    /// <param ></param>
    /// <returns></returns>
    /// <response code="200">Success</response>
    /// <response code="500">Internal Error</response>
    /// <response code="400">Bad Request</response>      
    [HttpGet(Name = "testapi")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<ActionResult> testapi()
    {
        DateTime dateNow = DateTime.Now;
        try
        {
            if (!ModelState.IsValid)
            {
                return GetInvalidModelResponse("CALLPLAN_ERROR_SEARCHCOMPANY_INPUT");
            }
            var result = await _service.GetEmp();
            return GetResponse(result);
        }
        catch (Exception ex)
        {
            return GetExceptionResponse("CALLPLAN_ERROR_SEARCHCOMPANY_CONTROLLER", ex);
        }
    }

}

