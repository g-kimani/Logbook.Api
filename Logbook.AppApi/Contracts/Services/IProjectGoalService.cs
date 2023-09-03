using Logbook.AppApi.DTOs.ProjectGoal;

namespace Logbook.AppApi.Contracts.Services
{
    public interface IProjectGoalService
    {
        Task<ProjectGoalResponseDto> Create( string userId, ProjectGoalCreateDto dto );
        Task<List<ProjectGoalResponseDto>> GetGoals( string userId, ProjectGoalRequestQuery query );
        Task<ProjectGoalResponseDto> GetGoalById( string userId, int goalId );
        Task DeleteGoalById( string userId, int goalId );
        Task<ProjectGoalResponseDto> UpdateGoalById(string userId, int goalId, ProjectGoalUpdateDto dto );
    }
}
