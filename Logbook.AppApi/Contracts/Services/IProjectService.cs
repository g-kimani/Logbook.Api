using Logbook.AppApi.DTOs;
using Logbook.AppApi.DTOs.Project;
using Logbook.AppApi.DTOs.ProjectGoal;
using Logbook.AppApi.DTOs.ProjectLog;

namespace Logbook.AppApi.Contracts.Services
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> Create( ProjectCreateDto dto, string userId );
        Task<List<ProjectShortResponseDto>> GetAllProjects(string userId, ProjectRequestQuery query);
        Task<ProjectFullResponseDto> GetProjectById( string userId, int projectId );
        Task<ProjectResponseDto> UpdateProject(string userId, int projectId, ProjectUpdateDto data);
        Task DeleteProject(string userId, int projectId );
        Task<List<ProjectLogResponseDto>> GetProjectLogs(string userId, int projectId, ProjectLogRequestQuery query );
        Task<List<ProjectGoalResponseDto>> GetProjectGoals( string userId, int projectId, ProjectGoalRequestQuery query );
    }
}
