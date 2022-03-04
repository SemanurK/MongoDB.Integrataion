using Ekmob.Technical.Customer.Entities;
using Ekmob.Technical.Customer.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentService departmentService,
            ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id:length(24)}", Name = "GetDepartmentById")]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Department>> GetDepartmentById(string id)
        {
            var department = await _departmentService.GetDepartment(id);
            if (department.Data == null)
            {
                _logger.LogError($"Department with id : {id}, not found");
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department department)
        {
            await _departmentService.AddDepartment(department);
            return CreatedAtRoute("GetDepartmentById", new { id = department.DepartmentId }, department);
        }
    }
}
