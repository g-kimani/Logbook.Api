using AutoMapper;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs.ProjectLog;

namespace Logbook.AppApi.MapperProfiles
{
    public class ProjectLogProfile : Profile
    {
        public ProjectLogProfile()
        {
            CreateMap<ProjectLog, ProjectLogResponseDto>();
            CreateMap<ProjectLogCreateDto, ProjectLog>();
        }
    }
}
