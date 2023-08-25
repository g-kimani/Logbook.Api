namespace Logbook.AppApi.DTOs.Project
{
    public class ProjectUpdateDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
