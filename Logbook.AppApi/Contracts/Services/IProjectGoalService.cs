using Logbook.AppApi.DTOs.ProjectGoal;

namespace Logbook.AppApi.Contracts.Services
{
    public interface IProjectGoalService
    {
        Task<ProjectGoalResponseDto> Create( string userId, ProjectGoalCreateDto dto );
        Task<List<ProjectGoalResponseDto>> GetGoals(string userId, ProjectGoalRequestQuery query);
    }
}
