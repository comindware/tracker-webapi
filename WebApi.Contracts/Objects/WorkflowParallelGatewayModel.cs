using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    public enum WorkflowParallelGatewayType
    {
        Undefined,

        Fork,
        Join
    }

    [DataContract]
    public class WorkflowParallelGatewayModel
    {
        /// <summary>
        /// Parallel gateway identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Gateway peer
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Peer { get; set; }

        /// <summary>
        /// Gateway name
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Name { get; set; }

        /// <summary>
        /// Current state
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public WorkflowState State { get; set; }

        /// <summary>
        /// Gateway type
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public WorkflowParallelGatewayType Type { get; set; }

        /// <summary>
        /// Gateway layout
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Layout { get; set; }
    }
}
