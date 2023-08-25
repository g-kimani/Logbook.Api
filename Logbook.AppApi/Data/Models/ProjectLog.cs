
using System.ComponentModel.DataAnnotations.Schema;

namespace Logbook.AppApi.Data.Models
{
    public class ProjectLog : BaseEntity
    {
        public int LogId { get; set; }
        public required string UserId { get; set; }

        public int ProjectId { get; set; }
        public DateTime EntryDate { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }

        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public required ApplicationUser User { get; set; }
        public required Project Project { get; set; }
    }
}