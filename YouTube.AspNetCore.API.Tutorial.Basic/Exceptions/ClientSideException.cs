namespace YouTube.AspNetCore.API.Tutorial.Basic.Exceptions
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string? message) : base(message)
        {
        }
    }
}
