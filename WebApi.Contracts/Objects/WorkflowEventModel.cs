using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class WorkflowEventModel
    {
        /// <summary>
        /// Event identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Event name
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Name { get; set; }

        /// <summary>
        /// Current state
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public WorkflowState State { get; set; }

        /// <summary>
        /// Event type
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public WorkflowEventType Type { get; set; }

        /// <summary>
        /// Event layout
        /// </summary>
        [DataMember]
        public string Layout { get; set; }
    }

    public enum WorkflowEventType
    {
        Undefined,

        Start,
        Intermediate,
        Stop
    }
}
