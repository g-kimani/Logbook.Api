using AutoMapper;
using Logbook.AppApi.Contracts.Exceptions;
using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.Data;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectTask;
using Microsoft.EntityFrameworkCore;

namespace Logbook.AppApi.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProjectTaskService( AppDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProjectTaskResponseDto>> GetTasks(string userId, ProjectTaskRequestQuery query )
        {
            var tasks = await _context.Tasks.Where( t => t.UserId == userId ).ToListAsync();
            switch (query.SortBy)
            {
                // NOTE: EntryDate and CreatedDate might be the same thing?
                case "created":
                    tasks = tasks.OrderBy( l => l.CreatedDate ).ToList();
                    break;
                case "title":
                    tasks = tasks.OrderBy( l => l.Title ).ToList();
                    break;
                default:
                    tasks = tasks.OrderBy( l => l.DueDate ).ToList();
                    break;
            }
            if (query.Order == "desc")
            {
                tasks.Reverse();
            }

            var result = _mapper.Map<List<ProjectTaskResponseDto>>( tasks );
            return result;
        }

        public async Task<ProjectTaskResponseDto> CreateTask(string userId, ProjectTaskCreateDto dto )
        {
            var project = await _context.Projects
                               .Where( p => p.UserId == userId && p.ProjectId == dto.ProjectId )
                               .FirstOrDefaultAsync();

            if (project == null)
            {
                throw new NotFoundException( $"Project {dto.ProjectId} not found" );
            }

            var task = _mapper.Map<ProjectTask>( dto );
            task.UserId = userId;
            task.Status = Data.Models.TaskStatus.NotStarted;

            _context.Tasks.Add( task );
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ProjectTaskResponseDto>( task );
            return result;
        }
    }
}
