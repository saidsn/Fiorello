namespace FiorelloApp.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool SoftDeleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
