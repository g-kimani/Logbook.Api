namespace Logbook.AppApi.DTOs.ProjectLog
{
    public class ProjectLogResponseDto : BaseDto
    {
        public int LogId { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public DateTime EntryDate { get; set; }
        public string? Content { get; set; }

    }
}
