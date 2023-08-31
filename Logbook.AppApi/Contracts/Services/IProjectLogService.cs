using AutoMapper.Configuration.Conventions;
using Logbook.AppApi.DTOs.ProjectLog;

namespace Logbook.AppApi.Contracts.Services
{
    public interface IProjectLogService
    {
        Task<List<ProjectLogResponseDto>> GetLogs( string userId, ProjectLogRequestQuery query );
        Task<List<ProjectLogResponseDto>> GetLogsForProject( string userId, int projectId, ProjectLogRequestQuery query );
        Task<ProjectLogResponseDto> GetLogById( string userId, int logId );
        Task<ProjectLogResponseDto> Create( string userId, ProjectLogCreateDto dto );
        Task<ProjectLogResponseDto> Update( string userId, ProjectLogUpdateDto dto );
        Task<ProjectLogResponseDto> Delete( string userId, int logId );
    }
}
