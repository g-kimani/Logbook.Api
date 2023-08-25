using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    public class ProjectTask : BaseEntity
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public required string UserId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public List<ProjectLog> Logs { get; set; } = new List<ProjectLog>();
        public required Project Project { get; set; }
        public required ApplicationUser User { get; set; }

    }
    public enum TaskStatus
    {
        NotStarted = 0, InProgress = 1, OnIce = 2, Completed = 3
    }
}
