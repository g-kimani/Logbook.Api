using AutoMapper;
using Logbook.AppApi.Contracts.Exceptions;
using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.Data;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs;
using Logbook.AppApi.DTOs.Project;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Logbook.AppApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectResponseDto> Create(ProjectCreateDto dto, string userId)
        {
            var project = _mapper.Map<Project>(dto);
            project.UserId = userId;

            await _context.AddAsync( project );
            await _context.SaveChangesAsync();

            var response = _mapper.Map<ProjectResponseDto>(project);

            return response;
        }

        public async Task<List<ProjectResponseDto>> GetAllProjects(string userId)
        {
            var projects = await _context.Projects.Where(p => p.UserId == userId).AsTracking().ToListAsync();
            // TODO : Find a more approachable way to do updates
            projects.ForEach( project =>
            {
                project.LastActiveDate = DateTime.UtcNow;
            } );
            await _context.SaveChangesAsync();
            return _mapper.Map<List<ProjectResponseDto>>(projects);
        }

        public async Task<ProjectFullResponseDto> GetProjectById(string userId, int projectId )
        {
            var project = await _context.Projects
                                        .Where(p => p.UserId == userId && p.ProjectId == projectId)
                                        .Include(p => p.Logs)
                                        .Include(p => p.Goals)
                                        .Include(p => p.Tasks)
                                        .AsTracking()
                                        .FirstOrDefaultAsync();


            if (project == null)
            {
                throw new NotFoundException( $"Project {projectId}" );
            }

            var lastActive = DateTime.UtcNow;
            project.LastActiveDate = lastActive;
            project.Logs.ForEach( p =>
            {
                p.LastActiveDate = lastActive;
            } );
            project.Goals.ForEach( p =>
            {
                p.LastActiveDate = lastActive;
            } );
            project.Tasks.ForEach( p =>
            {
                p.LastActiveDate = lastActive;
            } );
            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectFullResponseDto>( project );
        }

        public async Task<ProjectResponseDto> UpdateProject(string userId, int projectId, ProjectUpdateDto data)
        {
            if (projectId != data.ProjectId)
            {
                throw new BadRequestException( "Project id does not match" );
            }

            var project = await _context.Projects
                            .AsTracking()
                            .Where( p => p.UserId == userId && p.ProjectId == projectId )
                            .FirstOrDefaultAsync();

            if (project == null )
            {
                throw new NotFoundException( $"Project {projectId}" );
            }

            project.Title = data.Title;
            project.Content = data.Content;
            project.DueDate = data.DueDate;
            project.LastActiveDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectResponseDto>( project );
        }

        public async Task DeleteProject( string userId, int projectId )
        {
            var result = await _context.Projects
                             .Where( p => p.UserId == userId && p.ProjectId == projectId )
                             .ExecuteDeleteAsync();

            if (result == 0)
            {
                throw new NotFoundException( $"Project {projectId}" );
            }
        }

    }
}
