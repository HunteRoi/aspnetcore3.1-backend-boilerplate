namespace API.Infrastructure
{
    public class ClientSideError
    {
        public ErrorCodes Code { get; internal set; }

        public string Message { get; set; }
    }
}
