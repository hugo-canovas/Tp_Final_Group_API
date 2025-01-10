namespace tp_app_back.Models
{
    public class Attendance : BaseEntity
    {
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
