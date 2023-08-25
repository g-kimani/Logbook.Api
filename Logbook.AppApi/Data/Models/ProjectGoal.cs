using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    public class ProjectGoal : BaseEntity
    {
        public int ProjectGoalId { get; set; }
        public int ProjectId { get; set; }
        public required string UserId { get; set; }

        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? TargetCompletion { get; set; }
        public bool? IsCompleted { get; set; } = false;
        public DateTime CompletedDate { get; set; }
        public string? CompletedNotes { get; set; }

        public required Project Project { get; set; }
        public required ApplicationUser User { get; set; }
    }
}
