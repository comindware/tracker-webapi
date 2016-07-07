namespace Comindware.Platform.WebApi.Contracts
{
    public class WrongContainerTypeException : WebApiException
    {
        public WrongContainerTypeException(WebApiError error)
            : base(error.Message)
        { }

        public WrongContainerTypeException(string id) :
            base("Wrong container type. Container: " + id)
        {
        }
    }
}
