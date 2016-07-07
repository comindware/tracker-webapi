using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Workspace model
    /// </summary>
    [DataContract]
    public class WorkspaceModel
    {
        /// <summary>
        /// Workspace identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Workspace name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Workspace description
        /// </summary>
        [DataMember] 
        public string Description { get; set; }

        /// <summary>
        /// Container identifier that contains this workspace
        /// </summary>
        [DataMember]
        public InstanceModel ContainerId { get; set; } //ToDo add container id for workspaces
    }
}
