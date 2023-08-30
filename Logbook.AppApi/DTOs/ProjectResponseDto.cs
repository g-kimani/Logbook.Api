using Logbook.AppApi.DTOs.ProjectLog;

namespace Logbook.AppApi.DTOs
{
    public class ProjectResponseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? DueDate { get; set; }
        public List<ProjectLogResponseDto>? Logs { get; set; }

    }
}
