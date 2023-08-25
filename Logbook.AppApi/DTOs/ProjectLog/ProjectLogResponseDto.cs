namespace Logbook.AppApi.DTOs.ProjectLog
{
    public class ProjectLogResponseDto
    {
        public int ProjectLogId { get; set; }
        public int ProjectId { get; set; }
        public DateTime EntryDate { get; set; }
        public string? Content { get; set; }

    }
}
