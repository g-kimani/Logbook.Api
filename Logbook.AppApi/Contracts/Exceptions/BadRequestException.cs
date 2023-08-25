namespace Logbook.AppApi.Contracts.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException( string message ) : base( message ) { }
    }
}
