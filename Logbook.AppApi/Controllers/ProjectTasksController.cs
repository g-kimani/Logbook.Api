using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.DTOs.ProjectTask;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Logbook.AppApi.Controllers
{
    [Authorize]
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProjectTasksController : BaseController
    {
        private readonly IProjectTaskService _projectTaskService;
        public ProjectTasksController( ILogger<ProjectTasksController> logger, IProjectTaskService projectTaskService ) : base( logger )
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet]
        [ProducesResponseType( 200, Type = typeof( IEnumerable<ProjectTaskResponseDto> ) )]
        public async Task<IActionResult> GetUserTasks( [FromQuery] ProjectTaskRequestQuery query )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectTaskService.GetTasks( userId, query );
                return Ok( response );
            } );
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof( ProjectTaskResponseDto))]
        public async Task<IActionResult> PostTask( [FromBody] ProjectTaskCreateDto task )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectTaskService.CreateTask( userId, task );
                return Ok( response );
            } );
        }

    }
}
