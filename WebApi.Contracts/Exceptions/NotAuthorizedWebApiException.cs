namespace Comindware.Platform.WebApi.Contracts
{
    public class NotAuthorizedWebApiException : WebApiException
    {
        public NotAuthorizedWebApiException(WebApiError error)
            : base(error.Message)
        {
        }

        public NotAuthorizedWebApiException(string message)
            : base(message)
        {}
    }
}
