namespace Logbook.AppApi.DTOs
{
    public class ProjectCreateDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
