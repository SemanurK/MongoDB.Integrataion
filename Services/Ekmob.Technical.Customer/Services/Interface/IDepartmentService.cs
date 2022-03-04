using Ekmob.Technical.Common.Utilities.Response;
using Ekmob.Technical.Customer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Services.Interface
{
    public interface IDepartmentService
    {
        Task<Response<IEnumerable<Department>>> GetDepartments();
        Task<Response<Department>> GetDepartment(string id);
        Task<Response<Department>> AddDepartment(Department department);
    }
}
