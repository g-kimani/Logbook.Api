namespace Logbook.AppApi.DTOs
{
    public class AuthResultDto
    {
        public required string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
