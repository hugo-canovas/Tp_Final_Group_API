namespace tp_app_back.DTOs
{
    public class ProjectDto : GenericDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectEnd { get; set; }
        public List<int> EmployeeIds { get; set; }
    }
}
