namespace Logbook.AppApi.DTOs.ProjectTask
{
    public class ProjectTaskResponseDto
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
