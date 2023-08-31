namespace Logbook.AppApi.DTOs.Project
{
    public class ProjectUpdateDto : BaseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
