namespace tp_app_back.Models
{
    public class Attendance
    {
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
