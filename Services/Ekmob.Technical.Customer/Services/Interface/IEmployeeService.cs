using Ekmob.Technical.Common.Utilities.Response;
using Ekmob.Technical.Customer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Services.Interface
{
    public interface IEmployeeService
    {
        Task<Response<IEnumerable<Employee>>> GetEmployees();
        Task<Response<Employee>> GetEmployee(string id);
        Task<Response<Employee>> AddEmploye(Employee employee);
    }
}
