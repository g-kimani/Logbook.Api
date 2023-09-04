using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logbook.AppApi.Data;
using Logbook.AppApi.Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Logbook.AppApi.DTOs;
using Logbook.AppApi.Services;
using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.DTOs.Project;
using System.Runtime.InteropServices;
using Logbook.AppApi.DTOs.ProjectLog;
using Logbook.AppApi.DTOs.ProjectGoal;

namespace Logbook.AppApi.Controllers
{
    [Authorize]
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectsController( IProjectService projectService, ILogger<ProjectsController> logger ) : base( logger )
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType( 200, Type = typeof( IEnumerable<ProjectResponseDto> ) )]
        public async Task<IActionResult> GetProjects( [FromQuery] ProjectRequestQuery query )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.GetAllProjects( userId, query );
                return Ok( response );
            } );
        }

        [HttpPost]
        [ProducesResponseType( 201, Type = typeof( ProjectResponseDto ) )]
        public async Task<IActionResult> PostProject( [FromBody] ProjectCreateDto project )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.Create( project, userId );
                return CreatedAtAction( "PostProject", new { id = response.ProjectId }, response );
            } );
        }

        [HttpGet( "{id}" )]
        [ProducesResponseType( 200, Type = typeof( ProjectFullResponseDto ) )]
        public async Task<IActionResult> GetProject( int id )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var project = await _projectService.GetProjectById( userId, id );
                return Ok( project );
            } );
        }


        [HttpPatch( "{id}" )]
        [ProducesResponseType( 200, Type = typeof( ProjectResponseDto ) )]
        public async Task<IActionResult> PatchProject( int id, [FromBody] ProjectUpdateDto project )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.UpdateProject( userId, id, project );
                return Ok( response );

            } );
        }

        [HttpDelete( "{id}" )]
        [ProducesResponseType( 204 )]
        public async Task<IActionResult> DeleteProject( int id )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                await _projectService.DeleteProject( userId, id );
                return NoContent();
            } );
        }

        [HttpGet( "{id}/logs" )]
        [ProducesResponseType( 200, Type = typeof( IEnumerable<ProjectLogResponseDto> ) )]
        public async Task<IActionResult> GetProjectLogs( int id, [FromQuery] ProjectLogRequestQuery query )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.GetProjectLogs( userId, id, query );
                return Ok( response );
            } );
        }

        [HttpGet( "{id}/goals" )]
        [ProducesResponseType( 200, Type = typeof( IEnumerable<ProjectGoalResponseDto> ) )]
        public async Task<IActionResult> GetProjectGoals( int id, [FromQuery] ProjectGoalRequestQuery query )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.GetProjectGoals( userId, id, query );
                return Ok( response );
            } );
        }

    }
}
