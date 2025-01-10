using tp_app_back.DTO;
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

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _genericService.GetAllAsync();
            var dtos = employees.Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IsActive = employee.IsActive,
                RoleIds = employee.Roles?.Select(r => r.Id).ToList(),
                ProjectIds = employee.Projects?.Select(p => p.Id).ToList(),
                LeaveIds = employee.Leaves?.Select(l => l.Id).ToList(),
                AttendanceIds = employee.Attendances?.Select(a => a.Id).ToList()
            }).ToList();
            return dtos;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                IsActive = employeeDto.IsActive,
                Roles = employeeDto.RoleIds?.Select(id => new Role { Id = id }).ToList(),
                Projects = employeeDto.ProjectIds?.Select(id => new Project { Id = id }).ToList(),
                Leaves = employeeDto.LeaveIds?.Select(id => new Leave { Id = id }).ToList(),
                Attendances = employeeDto.AttendanceIds?.Select(id => new Attendance { Id = id }).ToList()
            };

            var newEmployee = await _genericService.CreateAsync(employee);

            return new EmployeeDto
            {
                Id = newEmployee.Id,
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                IsActive = newEmployee.IsActive,
                RoleIds = newEmployee.Roles.Select(r => r.Id).ToList(),
                ProjectIds = newEmployee.Projects.Select(p => p.Id).ToList(),
                LeaveIds = newEmployee.Leaves.Select(l => l.Id).ToList(),
                AttendanceIds = newEmployee.Attendances.Select(a => a.Id).ToList()
            };
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _genericService.GetByIdAsync(id);
            if (employee == null) return null;

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IsActive = employee.IsActive,
                RoleIds = employee.Roles.Select(r => r.Id).ToList(),
                ProjectIds = employee.Projects.Select(p => p.Id).ToList(),
                LeaveIds = employee.Leaves.Select(l => l.Id).ToList(),
                AttendanceIds = employee.Attendances.Select(a => a.Id).ToList()
            };
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                IsActive = employeeDto.IsActive,
                Roles = employeeDto.RoleIds?.Select(id => new Role { Id = id }).ToList(),
                Projects = employeeDto.ProjectIds?.Select(id => new Project { Id = id }).ToList(),
                Leaves = employeeDto.LeaveIds?.Select(id => new Leave { Id = id }).ToList(),
                Attendances = employeeDto.AttendanceIds?.Select(id => new Attendance { Id = id }).ToList()
            };

            var updatedEmployee = await _genericService.UpdateAsync(employee);

            return new EmployeeDto
            {
                Id = updatedEmployee.Id,
                FirstName = updatedEmployee.FirstName,
                LastName = updatedEmployee.LastName,
                IsActive = updatedEmployee.IsActive,
                RoleIds = updatedEmployee.Roles.Select(r => r.Id).ToList(),
                ProjectIds = updatedEmployee.Projects.Select(p => p.Id).ToList(),
                LeaveIds = updatedEmployee.Leaves.Select(l => l.Id).ToList(),
                AttendanceIds = updatedEmployee.Attendances.Select(a => a.Id).ToList()
            };
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }
    }
}
