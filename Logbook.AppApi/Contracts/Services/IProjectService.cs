﻿using Logbook.AppApi.DTOs;
using Logbook.AppApi.DTOs.Project;

namespace Logbook.AppApi.Contracts.Services
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> Create( ProjectCreateDto dto, string userId );
        Task<List<ProjectShortResponseDto>> GetAllProjects(string userId, ProjectRequestQuery query);
        Task<ProjectFullResponseDto> GetProjectById( string userId, int projectId );
        Task<ProjectResponseDto> UpdateProject(string userId, int projectId, ProjectUpdateDto data);
        Task DeleteProject(string userId, int projectId );
    }
}
