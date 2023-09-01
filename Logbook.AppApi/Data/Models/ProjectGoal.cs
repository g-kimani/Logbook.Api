using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    [PrimaryKey( "GoalId" )]
    public class ProjectGoal : BaseEntity
    {
        public int GoalId { get; set; }
        public int ProjectId { get; set; }
        public required string UserId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? TargetCompletion { get; set; }
        public bool? IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public string? CompletedNotes { get; set; }
        public Project? Project { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
