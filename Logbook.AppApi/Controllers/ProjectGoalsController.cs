using Logbook.AppApi.Contracts.Services;
using Logbook.AppApi.DTOs.ProjectGoal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Security.Permissions;

namespace Logbook.AppApi.Controllers
{
    [Authorize]
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProjectGoalsController : BaseController
    {
        private readonly IProjectGoalService _goalService;
        public ProjectGoalsController( IProjectGoalService goalService, ILogger<ProjectGoalsController> logger ) : base( logger )
        {
            _goalService = goalService;
        }

        [HttpPost]
        [ProducesResponseType( 201, Type = typeof( ProjectGoalResponseDto ) )]
        public async Task<IActionResult> PostProjectGoal( [FromBody] ProjectGoalCreateDto goal )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _goalService.Create( userId, goal );
                return Created( $"projectgoals/{response.GoalId}", response );

            } );
        }

        [HttpGet]
        [ProducesResponseType( 200, Type = typeof( ProjectGoalResponseDto ) )]
        public async Task<IActionResult> GetGoals( [FromQuery] ProjectGoalRequestQuery query )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _goalService.GetGoals( userId, query );
                return Ok( response );
            } );
        }

        [HttpGet( "{id}" )]
        [ProducesResponseType( 200, Type = typeof( ProjectGoalResponseDto ) )]
        public async Task<IActionResult> GetGoalById( int id )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _goalService.GetGoalById( userId, id );
                return Ok( response );
            } );
        }

        [HttpDelete( "{id}" )]
        [ProducesResponseType( 204 )]
        public async Task<IActionResult> DeleteGoalById( int id )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                await _goalService.DeleteGoalById( userId, id );
                return NoContent();
            } );
        }

        [HttpPatch( "{id}" )]
        [ProducesResponseType( 200, Type = typeof( ProjectGoalResponseDto ) )]
        public async Task<IActionResult> PatchGoalById( int id, [FromBody] ProjectGoalUpdateDto data )
        {
            return await ExecuteWithErrorHandling( async ( userId ) =>
            {
                var response = await _goalService.UpdateGoalById( userId, id, data );
                return Ok( response );
            } );
        }

    }
}
