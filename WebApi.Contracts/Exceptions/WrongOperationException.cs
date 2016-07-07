namespace Comindware.Platform.WebApi.Contracts
{
    public class WrongOperationException : WebApiException
    {
        public WrongOperationException(WebApiError error)
            : base(error.Message)
        { }
            
        public WrongOperationException(string id, string operation) : 
            base(string.Format("Wrong operation for this item. Item: {0}, operation: {1}", id, operation))
        { }
    }
}
