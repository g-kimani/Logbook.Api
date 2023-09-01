using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    [PrimaryKey( "TaskId" )]
    public class ProjectTask : BaseEntity
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int? ProjectLogId { get; set; }
        public required string UserId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public Project? Project { get; set; }
        public ApplicationUser? User { get; set; }
        public ProjectLog? ProjectLog { get; set; }

    }
    public enum TaskStatus
    {
        NotStarted = 0, InProgress = 1, OnIce = 2, Completed = 3
    }
}
