using AutoMapper;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs;
using Logbook.AppApi.DTOs.Project;
using Logbook.AppApi.DTOs.ProjectGoal;
using Logbook.AppApi.DTOs.ProjectLog;
using Logbook.AppApi.DTOs.ProjectTask;

namespace Logbook.AppApi.MapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Project, ProjectResponseDto>();
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectFullResponseDto>();
            CreateMap<ProjectLog,  ProjectLogResponseDto>();
            CreateMap<ProjectGoal, ProjectGoalResponseDto>();
            CreateMap<ProjectTask, ProjectTaskResponseDto>();
            CreateMap<Project, ProjectShortResponseDto>();
        }
    }
}
