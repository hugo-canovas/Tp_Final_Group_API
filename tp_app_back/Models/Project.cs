namespace tp_app_back.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime Project_Start { get; set; }
        public DateTime Project_End { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
