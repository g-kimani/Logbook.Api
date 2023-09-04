namespace Logbook.AppApi.DTOs.ProjectTask
{
    public class ProjectTaskCreateDto : BaseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }


    }
}
