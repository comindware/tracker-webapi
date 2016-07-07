using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class WorkflowModel
    {
        /// <summary>
        /// Workflow identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Workflow activity
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<string> Activity { get; set; }

        /// <summary>
        /// Workflow events list
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<WorkflowEventModel> Events { get; set; }

        /// <summary>
        /// Workflow gateways list
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<WorkflowParallelGatewayModel> Gateways { get; set; }

        /// <summary>
        /// Workflow transitions list
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<WorkflowTransitionModel> Transitions { get; set; }
    }
}
