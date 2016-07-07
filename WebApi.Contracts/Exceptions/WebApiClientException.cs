namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Core exceptions wrapper exception for web api
    /// </summary>
    public class WebApiClientException : WebApiException
    {
        /// Initializes a new instance of the <see cref="T:Platform.Core.WebApiClientException"/> class with specified message.
        public WebApiClientException(string message) : base(message)
        {
        }
    }
}
