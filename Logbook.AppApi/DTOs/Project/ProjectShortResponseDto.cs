using Logbook.AppApi.Data.Models;

namespace Logbook.AppApi.DTOs.Project
{
    public class ProjectShortResponseDto : BaseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
