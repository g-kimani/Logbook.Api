namespace Logbook.AppApi.DTOs.ProjectLog
{
    public class ProjectLogCreateDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
