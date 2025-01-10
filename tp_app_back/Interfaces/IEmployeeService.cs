using tp_app_back.DTOs;
using tp_app_back.Models;

namespace tp_app_back.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetAllEmployeesAsync();
        public Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employee);
        public Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        public Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employee);
        public Task<bool> DeleteEmployeeAsync(int id);

    }
}
