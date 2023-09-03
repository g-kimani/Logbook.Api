using AutoMapper;
using Logbook.AppApi.Contracts.Exceptions;
using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.Data;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectGoal;
using Microsoft.EntityFrameworkCore;

namespace Logbook.AppApi.Services
{
    public class ProjectGoalService : IProjectGoalService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProjectGoalService( AppDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectGoalResponseDto> Create( string userId, ProjectGoalCreateDto dto )
        {
            var project = await _context.Projects
                               .Where( p => p.UserId == userId && p.ProjectId == dto.ProjectId )
                               .FirstOrDefaultAsync();
            if (project == null)
            {
                throw new NotFoundException( $"Project {dto.ProjectId} not found" );
            }

            var goal = _mapper.Map<ProjectGoal>( dto );
            goal.UserId = userId;

            _context.Goals.Add( goal );
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ProjectGoalResponseDto>( goal );
            return result;
        }

        public async Task<List<ProjectGoalResponseDto>> GetGoals( string userId, ProjectGoalRequestQuery query )
        {
            var goals = await _context.Goals.Where( p => p.UserId == userId ).ToListAsync();

            switch (query.SortBy)
            {
                case "completed":
                    goals = goals.OrderBy( l => l.CompletedDate ).ToList();
                    break;
                case "title":
                    goals = goals.OrderBy( l => l.Title ).ToList();
                    break;
                default:
                    goals = goals.OrderBy( l => l.CreatedDate ).ToList();
                    break;
            }
            if (query.Order == "desc")
            {
                goals.Reverse();
            }

            var result = _mapper.Map<List<ProjectGoalResponseDto>>( goals );
            return result;
        }

        public async Task<ProjectGoalResponseDto> GetGoalById( string userId, int goalId )
        {
            var goal = await _context.Goals
                        .AsTracking()
                        .FirstOrDefaultAsync( g => g.GoalId == goalId && g.UserId == userId );

            if (goal == null)
            {
                throw new NotFoundException( $"Goal {goalId} not found" );
            }

            goal.LastActiveDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ProjectGoalResponseDto>( goal );
            return result;
        }

        public async Task DeleteGoalById( string userId, int goalId )
        {
            var result = await _context.Goals
                            .Where( g => g.GoalId == goalId && g.UserId == userId )
                            .ExecuteDeleteAsync();

            if (result == 0)
            {
                throw new NotFoundException( $"Goal {goalId} not found" );
            }
        }

        public async Task<ProjectGoalResponseDto> UpdateGoalById(string userId, int goalId, ProjectGoalUpdateDto update )
        {
            var goal = await _context.Goals.AsTracking().FirstOrDefaultAsync( g => g.UserId == userId && g.GoalId == goalId );

            if (goal == null)
            {
                throw new NotFoundException( $"Goal {goalId} not found" );
            }

            goal.Title = update.Title ?? goal.Title;
            goal.Content = update.Content ?? goal.Content;
            goal.TargetCompletion = update.TargetCompletion ?? goal.TargetCompletion;
            goal.IsCompleted = update.IsCompleted;
            if (update.IsCompleted)
            {
                goal.CompletedDate =  update.CompletedDate ?? DateTime.UtcNow;
                goal.CompletedNotes = update.CompletedNotes;
            }

            await _context.SaveChangesAsync();

            var result = _mapper.Map<ProjectGoalResponseDto>( goal );
            return result;
        }

    }
}
