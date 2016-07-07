using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class WorkflowTransitionModel
    {
        /// <summary>
        /// Transition identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Transition name
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Name { get; set; }

        /// <summary>
        /// Transition source
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Source { get; set; }

        /// <summary>
        /// Transition target
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Target { get; set; }

        /// <summary>
        /// Transition source uid
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string SourceUid { get; set; }

        /// <summary>
        /// Transition target uid
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string TargetUid { get; set; }
    }
}
