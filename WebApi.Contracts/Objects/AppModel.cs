using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Application model
    /// </summary>
    [DataContract]
    public class AppModel
    {
        /// <summary>
        /// Application identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Application name
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Name { get; set; }

        /// <summary>
        /// Application description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Kind.
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public ItemKind Kind { get; set; }

        /// <summary>
        /// Workspaces that contain this application
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<InstanceModel> Workspaces { get; set; }
    }
}
