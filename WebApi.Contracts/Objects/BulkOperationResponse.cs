using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class SingleOperationResult
    {
        public SingleOperationResult(string objectId, WebApiError error = null, bool success = true)
        {
            Error = error;
            Success = success;
            ObjectId = objectId;
        }

        [DataMember]
        public string ObjectId { get; set; }

        [DataMember(IsRequired = true), Required]
        public bool Success { get; set; }

        [DataMember]
        public WebApiError Error { get; set; }
    }

    [DataContract]
    public class BulkOperationResult
    {
        [DataMember]
        public List<SingleOperationResult> SubOperations { get; set; }
    }
}
