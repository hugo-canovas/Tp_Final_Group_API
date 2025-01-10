using tp_app_back.DTOs;
using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericService<Employee> _genericService;

        public EmployeeService(IGenericService<Employee> genericService)
        {
            _genericService = genericService;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _genericService.GetAllAsync();
            return employees;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                IsActive = employeeDto.IsActive,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };

            await _genericService.CreateAsync(employee);

            return employee;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _genericService.GetByIdAsync(id);
            if (employee == null) return null;

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var existingEmployee = await GetEmployeeByIdAsync(id);

            if (existingEmployee == null) return null;

            existingEmployee.FirstName = employeeDto.FirstName;
            existingEmployee.LastName = employeeDto.LastName;
            existingEmployee.IsActive = employeeDto.IsActive;
            existingEmployee.UpdatedOn = DateTime.UtcNow;

            await _genericService.UpdateAsync(existingEmployee);

            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }
    }
}
