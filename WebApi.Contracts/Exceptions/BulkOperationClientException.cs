using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Thrown in client if bulk operation error occurred
    /// Bulk operation exception must be accumulated in action response BulkOperationResult list.
    /// </summary>
    public class BulkOperationClientException : WebApiException
    {
        public IEnumerable<WebApiError> InnerExceptions { get; private set; }

        public object Data { get; private set; }

        public BulkOperationClientException(IEnumerable<WebApiError> errors, object data = null)
            : base("Web Api Bulk error occurred.")
        {
            InnerExceptions = errors;
            Data = data;
        }
    }
}
