using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Datasets Query parameters
    /// </summary>
    [DataContract]
    public class DatasetsQuery
    {
        /// <summary>
        /// Query Datasets by Identifiers
        /// </summary>
        [DataMember]
        public string[] Ids { get; set; }

        /// <summary>
        /// Query Datasets by Application Identifier
        /// </summary>
        [DataMember]
        public string ApplicationId { get; set; }
    }
}
