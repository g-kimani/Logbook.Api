using AutoMapper;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs;

namespace Logbook.AppApi.MapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Project, ProjectResponseDto>();
            CreateMap<ProjectCreateDto, Project>();
        }
    }
}
