namespace tp_app_back.DTOs
{
    public class LeaveDto : GenericDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
    }
}
