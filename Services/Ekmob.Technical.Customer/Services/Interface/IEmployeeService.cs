using System.Collections.Generic;
using System.Threading.Tasks;
using Ekmob.Technical.Common.Utilities.Response;
using Ekmob.Technical.Services.Entities;

namespace Ekmob.Technical.Services.Services.Interface
{
    public interface IEmployeeService
    {
        Task<Response<IEnumerable<Employee>>> GetEmployees();
        Task<Response<Employee>> GetEmployee(string id);
        Task<Response<Employee>> AddEmploye(Employee employee);
    }
}
