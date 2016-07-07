namespace Comindware.Platform.WebApi.Contracts
{
    public class ObjectNotFoundWebApiException : WebApiException
    {
        public ObjectNotFoundWebApiException(WebApiError error)
            : base(error.Message)
        {
        }

        public ObjectNotFoundWebApiException(string message)
            : base(message)
        {}
    }
}
