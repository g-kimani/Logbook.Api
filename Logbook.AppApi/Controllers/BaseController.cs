using Logbook.AppApi.Contracts.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Logbook.AppApi.Controllers
{
    // TODO: When more than one child put ApiController attribute here 
    public class BaseController : ControllerBase
    {
        protected ILogger Logger { get; set; }

        protected BaseController( ILogger logger )
        {
            Logger = logger;
        }

        protected async Task<IActionResult> ExecuteWithErrorHandling<T>( Func<string, Task<T>> action ) where T : IActionResult
        {
            var userId = User.FindFirst( ClaimTypes.NameIdentifier )?.Value;
            if (userId == null)
            {
                return BadRequest();
            }
            try
            {
                return Ok( await action( userId ) );
            }
            catch (NotFoundException ex)
            {
                return NotFound( ex.Message );
            }
            catch (BadRequestException ex)
            {
                return BadRequest( ex.Message );
            }
        }
    }
}
