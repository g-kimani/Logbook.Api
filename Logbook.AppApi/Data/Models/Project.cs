using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    public class Project : BaseEntity
    {
        public int ProjectId { get; set; }
        public required string UserId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public ApplicationUser? User { get; set; }
        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public List<ProjectLog> Logs { get; set; } = new List<ProjectLog>();
        public List<ProjectGoal> Goals { get; set; } = new List<ProjectGoal>();

    }

    public enum ProjectStatus
    {
        NotStarted = 0, InProgress = 1, OnIce = 2, Completed = 3
    }
}
