﻿using System;
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

namespace Logbook.AppApi.Controllers
{
    [Authorize]
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IProjectService _projectService;

        public ProjectsController( AppDbContext context, IProjectService projectService, ILogger<ProjectsController> logger ) : base( logger )
        {
            _context = context;
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        [ProducesResponseType( 200, Type = typeof( IEnumerable<ProjectResponseDto> ) )]
        public async Task<IActionResult> GetProjects()
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.GetAllProjects( userId );
                return Ok( response );
            } );
        }


        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType( 201, Type = typeof( ProjectResponseDto ) )]
        public async Task<IActionResult> PostProject( [FromBody] ProjectCreateDto project )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectService.Create( project, userId );
                return CreatedAtAction( "CreateProject", new { id = response.ProjectId }, response );
            } );
        }

        // GET: api/Projects/5
        [HttpGet( "{id}" )]
        [ProducesResponseType( 200, Type = typeof( ProjectResponseDto ) )]
        public async Task<IActionResult> GetProject( int id )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var project = await _projectService.GetProjectById( userId, id );
                return Ok( project );
            } );
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/Projects/5
        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteProject( int id )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                await _projectService.DeleteProject( userId, id );
                return NoContent();
            } );
        }

    }
}