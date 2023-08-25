using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Logbook.AppApi.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
