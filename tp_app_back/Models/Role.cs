namespace tp_app_back.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
