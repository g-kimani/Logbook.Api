namespace Logbook.AppApi.DTOs
{
    public class AuthResultDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
