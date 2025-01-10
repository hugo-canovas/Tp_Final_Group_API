namespace tp_app_back.DTOs
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<int> EmployeeIds { get; set; }
    }
}
