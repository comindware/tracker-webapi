namespace Comindware.Platform.WebApi.Contracts
{
    public class ErrorStatusCodeClientException : WebApiException
    {
        /// <summary>
        /// Response data
        /// </summary>
        public object Data { get; set; }

        public ErrorStatusCodeClientException(int statusCode, object data)
            : base("Error status code returned from server: " + statusCode)
        {
            this.Data = data;
        }
    }
}
