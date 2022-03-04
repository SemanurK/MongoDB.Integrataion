using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ekmob.Technical.Services.Entities;
using Ekmob.Technical.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ekmob.Technical.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService,
            ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            if (employees.Data != null)
                return Ok(employees);
            else
                return NotFound();
        }

        [HttpGet("{id:length(24)}", Name = "GetEmployeeById")]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Employee>> GetEmployeeById(string id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee.Data == null)
            {
                _logger.LogError($"Employee with id : {id}, not found");
                return NotFound();
            }

            return Ok(employee);
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(Employee), (int)HttpStatusCode.Created)]
        //public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        //{
        //    await _employeeService.AddEmploye(employee);
        //    return CreatedAtRoute("GetEmployeeById", new { id = employee.EmployeeId }, employee);
        //}
    }
}
