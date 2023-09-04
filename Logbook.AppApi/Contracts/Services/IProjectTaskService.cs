using Logbook.AppApi.DTOs.ProjectTask;

namespace Logbook.AppApi.Contracts.Services
{
    public interface IProjectTaskService
    {
        Task<List<ProjectTaskResponseDto>> GetTasks( string userId, ProjectTaskRequestQuery query );
        Task<ProjectTaskResponseDto> CreateTask( string userId, ProjectTaskCreateDto dto );
    }
}
