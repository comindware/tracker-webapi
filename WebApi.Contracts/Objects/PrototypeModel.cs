using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Prototype model
    /// </summary>
    [DataContract]
    public class PrototypeModel
    {
        /// <summary>
        /// Prototype id
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Prototype name
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Name { get; set; }

        /// <summary>
        /// Prototype description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Workflow identifier
        /// </summary>
        [DataMember]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Custom Form identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string CustomFormId { get; set; }

        /// <summary>
        /// Kind
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public ItemKind Kind { get; set; }

        /// <summary>
        /// Containers that contain this prototype
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<InstanceModel> UsedInContainer { get; set; }

        /// <summary>
        /// Item's properties
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<PropertyModel> Properties { get; set; }
    }
}
