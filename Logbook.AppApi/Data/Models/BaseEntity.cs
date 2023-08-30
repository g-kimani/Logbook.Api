namespace Logbook.AppApi.Data.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastActiveDate { get; set; } = DateTime.UtcNow;
    }
}
