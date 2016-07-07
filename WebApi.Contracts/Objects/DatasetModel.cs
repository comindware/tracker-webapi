using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Dataset model
    /// </summary>
    [DataContract]
    public class DatasetModel
    {
        /// <summary>
        /// Dataset identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Dataset name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Dataset description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Container that contains this dataset
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public InstanceModel Container { get; set; }
    }
}
