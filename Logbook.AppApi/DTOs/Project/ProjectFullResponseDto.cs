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
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public List<ProjectTaskResponseDto> Tasks { get; set; }
        public List<ProjectLogResponseDto> Logs { get; set; }
        public List<ProjectGoalResponseDto> Goals { get; set; }

    }
}
