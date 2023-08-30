using Logbook.AppApi.Data;
using Logbook.AppApi.Data.Models;
using Logbook.AppApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logbook.AppApi.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            AppDbContext dbContext )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = dbContext;
        }

        [HttpPost( "register" )]
        public async Task<IActionResult> Register( [FromBody] UserRegisterDto user )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest( ModelState );
            }

            var userExists = await _userManager.FindByEmailAsync( user.Email );
            if (userExists != null)
            {
                return BadRequest( $"User {user.Email} already exists" );
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Email,
                UserName = user.Username
            };

            var result = await _userManager.CreateAsync( newUser, user.Password );

            if (result.Succeeded) return Ok( "User Created" );
            else
            {
                // need to handle cases like username already exists / password not strong
                return BadRequest( result.Errors );
            }
        }

        [HttpPost( "login" )]
        public async Task<IActionResult> Login( [FromBody] UserLoginDto user )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest( ModelState );
            }

            var userExists = await _userManager.FindByEmailAsync( user.Email );
            if (userExists != null && await _userManager.CheckPasswordAsync( userExists, user.Password ))
            {
                var tokenValue = GenerateJWTToken( userExists );
                return Ok(tokenValue);
            }
            return Unauthorized();
        }

        private AuthResultDto GenerateJWTToken( ApplicationUser user )
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes( _configuration["JWT:Key"] ));

            var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    // TODO: Work on refresh tokens
                    expires: DateTime.UtcNow.AddMinutes(30),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new AuthResultDto()
            {
                Token = jwtToken,
                ExpiresAt = token.ValidTo
            };

            return response;
        }
    }
}
