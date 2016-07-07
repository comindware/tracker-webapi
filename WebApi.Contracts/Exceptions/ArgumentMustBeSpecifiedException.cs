namespace Comindware.Platform.WebApi.Contracts
{
    public class ArgumentMustBeSpecifiedException : WebApiException
    {
        public ArgumentMustBeSpecifiedException(WebApiError error)
            : base(error.Message)
        {
        }

        public ArgumentMustBeSpecifiedException(string arg)
            : base("Method argument must be specified: " + arg)
        {}

    }
}
    