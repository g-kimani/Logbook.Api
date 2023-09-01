using AutoMapper;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectGoal;

namespace Logbook.AppApi.MapperProfiles
{
    public class ProjectGoalProfile : Profile
    {
        public ProjectGoalProfile() 
        {
            CreateMap<ProjectGoal, ProjectGoalResponseDto>();
            CreateMap<ProjectGoalCreateDto, ProjectGoal>();
        }
    }
}
