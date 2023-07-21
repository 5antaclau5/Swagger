
using Microsoft.EntityFrameworkCore;
using SwaggerAPI.Data;
using SwaggerAPI.Models;
using SwaggerAPI.Entities;
using SwaggerAPI.Service.Employee;
using SwaggerAPI.Repository;
using Api.Models;
using SwaggerAPI.Helper;

namespace SwaggerAPI.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly DataContext _context;
        private readonly EmployeeRepository _repo;
        public EmployeeService(EmployeeRepository repo, DataContext context)
        {
            this._context = context;
            this._repo = repo;
        }

        public async Task<bool> AddEmp(EmployeeModels data)
        {
            await _repo.testretrunstring();

            return true;
        }

        public async Task<BaseResponse<List<TbEmployee>>> GetEmp()
        {
            var result = new BaseResponse<List<TbEmployee>>();
            result.Data = await _repo.testretrunstring();
            result.SetResponseSuccess("db");
            return result;
        }
    }
}