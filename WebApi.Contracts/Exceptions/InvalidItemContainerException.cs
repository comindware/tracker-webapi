namespace Comindware.Platform.WebApi.Contracts
{
    public class InvalidItemContainerException : WebApiException
    {
        public InvalidItemContainerException(WebApiError error)
            : base(error.Message)
        { }

        public InvalidItemContainerException(string container) :
            base("Invalid item container: " + container)
        { }
    }
}
