
using System.ComponentModel.DataAnnotations;

namespace Logbook.AppApi.DTOs
{

    public class UserRegisterDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
