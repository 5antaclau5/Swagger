using Api.Models;
using SwaggerAPI.Entities;
using SwaggerAPI.Models;

namespace SwaggerAPI.Service.Employee
{
    public interface IEmployee
    {
        public Task<BaseResponse<List<TbEmployee>>> GetEmp();
        public Task<bool> AddEmp(EmployeeModels data);

    }
}
