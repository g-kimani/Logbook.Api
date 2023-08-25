namespace Logbook.AppApi.DTOs.ProjectGoal
{
    public class ProjectGoalResponseDto
    {
        public int ProjectGoalId { get; set; }
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? TargetCompletion { get; set; }
        public bool? IsCompleted { get; set; } = false;
        public DateTime CompletedDate { get; set; }
        public string? CompletedNotes { get; set; }
    }
}
