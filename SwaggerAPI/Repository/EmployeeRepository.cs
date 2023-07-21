using SwaggerAPI.Data;
using Microsoft.EntityFrameworkCore;
using SwaggerAPI.Entities;

namespace SwaggerAPI.Repository
{
    public class EmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<TbEmployee>> testretrunstring()
        {
            List<TbEmployee> lst =  _context.TbEmployees.ToList();
            return lst;
        }
    }
}