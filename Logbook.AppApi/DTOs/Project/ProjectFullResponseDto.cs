using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectGoal;
using Logbook.AppApi.DTOs.ProjectLog;
using Logbook.AppApi.DTOs.ProjectTask;
using Microsoft.Identity.Client;

namespace Logbook.AppApi.DTOs.Project
{
    public class ProjectFullResponseDto
    {
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public List<ProjectTaskResponseDto> Tasks { get; set; } = new List<ProjectTaskResponseDto>();
        public List<ProjectLogResponseDto> Logs { get; set; } = new List<ProjectLogResponseDto>();
        public List<ProjectGoalResponseDto> Goals { get; set; } = new List<ProjectGoalResponseDto>();
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
