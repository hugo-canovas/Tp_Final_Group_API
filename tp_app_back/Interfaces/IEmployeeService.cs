using tp_app_back.DTOs;
using tp_app_back.Models;

namespace tp_app_back.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> CreateEmployeeAsync(EmployeeDto employee);
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> UpdateEmployeeAsync(Employee employee);
        public Task<bool> DeleteEmployeeAsync(int id);

    }
}
