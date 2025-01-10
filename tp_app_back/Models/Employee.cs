namespace tp_app_back.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public List<Role> Roles { get; set; } = [];
        public List<Project> Projects { get; set; } = [];
        public List<Leave> Leaves { get; set; } = [];
        public List<Attendance> Attendances { get; set; } = [];
    }
}
