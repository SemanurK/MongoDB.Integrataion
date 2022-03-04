using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ekmob.Technical.Common.Utilities.Response;
using Ekmob.Technical.Customer.Data.Interface;
using Ekmob.Technical.Services.Entities;
using Ekmob.Technical.Services.Services.Interface;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace Ekmob.Technical.Services.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseContext _baseContext;
        private readonly IDepartmentService _departmentService;

        public EmployeeService(IBaseContext baseContext,IDepartmentService departmentService)
        {
            _baseContext = baseContext;
            _departmentService = departmentService;
        }

        public async Task<Response<IEnumerable<Employee>>> GetEmployees()
        {
            var employes = await _baseContext.Employees.Find(x => true).ToListAsync();

            if (employes.Any())
            {
                foreach (var employe in employes)
                {
                    var departmentResult = await _departmentService.GetDepartment(employe.DepartmentId);
                   
                    if (!departmentResult.IsSuccessful)
                        return Response<IEnumerable<Employee>>.Fail("Null department", StatusCodes.Status404NotFound);
                    else
                        employe.Department = departmentResult.Data;

                    //var departmentResult = await _baseContext.Departments
                    //    .Find(x => x.DepartmentId == employe.DepartmentId).FirstAsync();
                    //employe.Department = await _baseContext.Departments
                    //    .Find(x => x.DepartmentId == employe.DepartmentId).FirstAsync();
                }
            }
            else
                employes = new List<Employee>();

            return Response<IEnumerable<Employee>>.Success(employes, StatusCodes.Status200OK);
        }

        public async Task<Response<Employee>> GetEmployee(string id)
        {
            var employee = await _baseContext.Employees.Find(x => x.EmployeeId == id).FirstOrDefaultAsync();
            if (employee == null)
                return Response<Employee>.Fail("Not found employee", StatusCodes.Status404NotFound);

            employee.Department = await _baseContext.Departments.Find<Department>(x => x.DepartmentId == employee.DepartmentId).FirstAsync();

            return Response<Employee>.Success(employee, StatusCodes.Status200OK);
        }

        public async Task<Response<Employee>> AddEmploye(Employee employee)
        {
            await _baseContext.Employees.InsertOneAsync(employee);

            return Response<Employee>.Success(employee, StatusCodes.Status200OK);
        }
    }
}
