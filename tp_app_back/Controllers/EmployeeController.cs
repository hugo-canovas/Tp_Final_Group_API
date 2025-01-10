using Microsoft.AspNetCore.Mvc;
using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            var newEmployee = await _employeeService.CreateEmployeeAsync(employee);
            return Ok(newEmployee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var getEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(getEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var getEmployee = await _employeeService.GetEmployeeByIdAsync(id);

            if (getEmployee != null)
            {
                return NotFound();
            }
            if(id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok(getEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var oldEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (oldEmployee == null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }

    }
}
