namespace tp_app_back.Models
{
    public class Projects : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        public DateTime Project_Start { get; set; }
        public DateTime Project_End { get; set; }
    }
}
