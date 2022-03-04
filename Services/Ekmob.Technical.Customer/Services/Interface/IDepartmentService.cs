using System.Collections.Generic;
using System.Threading.Tasks;
using Ekmob.Technical.Common.Utilities.Response;
using Ekmob.Technical.Services.Entities;

namespace Ekmob.Technical.Services.Services.Interface
{
    public interface IDepartmentService
    {
        Task<Response<IEnumerable<Department>>> GetDepartments();
        Task<Response<Department>> GetDepartment(string id);
        Task<Response<Department>> AddDepartment(Department department);
    }
}
