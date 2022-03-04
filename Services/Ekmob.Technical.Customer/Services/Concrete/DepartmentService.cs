using Ekmob.Technical.Common.Utilities.Response;
using Ekmob.Technical.Customer.Data.Interface;
using Ekmob.Technical.Customer.Entities;
using Ekmob.Technical.Customer.Services.Interface;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IBaseContext _baseContext;

        public DepartmentService(IBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<Response<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _baseContext.Departments.Find(x => true).ToListAsync();

            return Response<IEnumerable<Department>>.Success(departments, StatusCodes.Status200OK);
        }

        public async Task<Response<Department>> GetDepartment(string id)
        {
            var department = await _baseContext.Departments.Find(x => x.DepartmentId == id).FirstOrDefaultAsync();
            if (department == null)
                return Response<Department>.Fail("Not found department", StatusCodes.Status404NotFound); 

            return Response<Department>.Success(department, StatusCodes.Status200OK);
        }

        public async Task<Response<Department>> AddDepartment(Department department)
        {
            await _baseContext.Departments.InsertOneAsync(department);

            return Response<Department>.Success(department, StatusCodes.Status200OK);
        }
    }
}
