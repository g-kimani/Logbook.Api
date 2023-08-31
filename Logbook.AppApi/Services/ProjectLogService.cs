using AutoMapper;
using Logbook.AppApi.Contracts.Exceptions;
using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.Data;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectLog;
using Microsoft.EntityFrameworkCore;

namespace Logbook.AppApi.Services
{
    public class ProjectLogService : IProjectLogService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProjectLogService( AppDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectLogResponseDto> Create( string userId, ProjectLogCreateDto dto )
        {
            var project = _context.Projects.Where( p => p.ProjectId == dto.ProjectId ).FirstOrDefault();
            if (project == null)
            {
                throw new NotFoundException( $"Project {dto.ProjectId} not found" );
            }
            var projectLog = _mapper.Map<ProjectLog>( dto );
            projectLog.UserId = userId;
            projectLog.EntryDate = DateTime.UtcNow;

            _context.Logs.Add( projectLog );
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ProjectLogResponseDto>( projectLog );
            return result;
        }
        public async Task<List<ProjectLogResponseDto>> GetLogs( string userId, ProjectLogRequestQuery query )
        {
            var logs = await _context.Logs.Where( p => p.UserId == userId ).ToListAsync();
            switch (query.SortBy)
            {
                // NOTE: EntryDate and CreatedDate might be the same thing?
                case "created":
                    logs = logs.OrderBy( l => l.CreatedDate ).ToList();
                    break;
                case "title":
                    logs = logs.OrderBy( l => l.Title ).ToList();
                    break;
                default:
                    logs = logs.OrderBy( l => l.EntryDate ).ToList();
                    break;
            }
            if (query.Order == "desc")
            {
                logs.Reverse();
            }

            var result = _mapper.Map<List<ProjectLogResponseDto>>( logs );
            return result;
        }

        public Task<List<ProjectLogResponseDto>> GetLogsForProject( string userId, int projectId, ProjectLogRequestQuery query )
        {

            throw new NotImplementedException();
        }

        public Task<ProjectLogResponseDto> Delete( string userId, int logId )
        {
            throw new NotImplementedException();
        }

        public Task<ProjectLogResponseDto> GetLogById( string userId, int logId )
        {
            throw new NotImplementedException();
        }

        public Task<ProjectLogResponseDto> Update( string userId, ProjectLogUpdateDto dto )
        {
            throw new NotImplementedException();
        }
    }
}
