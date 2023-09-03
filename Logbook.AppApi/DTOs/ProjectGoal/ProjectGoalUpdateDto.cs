namespace Logbook.AppApi.DTOs.ProjectGoal
{
    public class ProjectGoalUpdateDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? TargetCompletion { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public string? CompletedNotes { get; set; }

    }
}
