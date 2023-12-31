﻿namespace Logbook.AppApi.DTOs.ProjectGoal
{
    public class ProjectGoalCreateDto : BaseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime? TargetCompletion { get; set; }
    }
}
