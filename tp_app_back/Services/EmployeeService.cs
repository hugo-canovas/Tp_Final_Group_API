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

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var newEmployee = await _genericService.CreateAsync(employee);
            return newEmployee;    
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var getEmployee = await _genericService.GetByIdAsync(id);
            return getEmployee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var updateEmployee = await _genericService.UpdateAsync(employee);
            return updateEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var oldEmployee = await _genericService.DeleteAsync(id);
            return oldEmployee;
        }

    }
}
