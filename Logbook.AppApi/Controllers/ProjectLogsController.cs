using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.DTOs.ProjectLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logbook.AppApi.Controllers
{
    [Authorize]
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProjectLogsController : BaseController
    {
        private readonly IProjectLogService _projectLogService;
        public ProjectLogsController( IProjectLogService projectLogService, ILogger<ProjectLogsController> logger ) : base( logger )
        {
            _projectLogService = projectLogService;
        }

        [HttpPost]
        [ProducesResponseType( 201, Type = typeof( ProjectLogResponseDto ) )]
        public async Task<IActionResult> PostProjectLog( [FromBody] ProjectLogCreateDto dto )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectLogService.Create( userId, dto );
                //var response = new { User = 1, Game = 2 };
                return Ok( response );
            } );
        }

        [HttpGet]
        [ProducesResponseType( 200, Type = typeof( IEnumerable<ProjectLogResponseDto> ) )]
        public async Task<IActionResult> GetLogs( [FromQuery] ProjectLogRequestQuery query)
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _projectLogService.GetLogs( userId, query );
                return Ok( response );
            } );
        }

    }
}
