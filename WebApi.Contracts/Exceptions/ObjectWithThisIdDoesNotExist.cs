namespace Comindware.Platform.WebApi.Contracts
{
    public class ObjectWithThisIdDoesNotExist : WebApiException
    {
        public ObjectWithThisIdDoesNotExist(WebApiError error)
            : base(error.Message)
        { }

        public ObjectWithThisIdDoesNotExist(string id) :
            base("Object with this id does not exist. Object id: " + id)
        { }
    }
}
