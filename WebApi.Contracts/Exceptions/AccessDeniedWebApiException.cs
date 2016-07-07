namespace Comindware.Platform.WebApi.Contracts
{
    public class AccessDeniedWebApiException : WebApiException
    {
        public AccessDeniedWebApiException(WebApiError error)
            : base(error.Message)
        {
        }

        public AccessDeniedWebApiException(string message)
            : base(message)
        {}
    }
}
