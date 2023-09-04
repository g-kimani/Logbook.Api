using AutoMapper;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectTask;

namespace Logbook.AppApi.MapperProfiles
{
    public class ProjectTaskProfile : Profile
    {
        public ProjectTaskProfile()
        {
            CreateMap<ProjectTask, ProjectTaskResponseDto>();
            CreateMap<ProjectTaskCreateDto, ProjectTask>();
        }
    }
}
