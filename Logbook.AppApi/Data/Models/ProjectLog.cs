
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    [PrimaryKey( "LogId" )]
    public class ProjectLog : BaseEntity
    {
        public int LogId { get; set; }
        public required string UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime EntryDate { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public ApplicationUser? User { get; set; }
        public Project? Project { get; set; }
    }
}