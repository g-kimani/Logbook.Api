﻿namespace Logbook.AppApi.DTOs
{
    public class ProjectResponseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}