namespace tp_app_back.Models
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
