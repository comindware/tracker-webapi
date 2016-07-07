using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Property model
    /// </summary>
    [DataContract]
    public class PropertyModel
    {
        /// <summary>
        /// Property identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Property name
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Name { get; set; }

        /// <summary>
        /// Property description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Property data type
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public DataType DataType { get; set; }

        /// <summary>
        /// readonly property flag
        /// </summary>
        [DataMember]
        public bool IsReadonly { get; set; }

        /// <summary>
        /// Calculated property flag
        /// </summary>
        [DataMember]
        public bool IsCalculated { get; set; }

        /// <summary>
        /// Multivalue property flag
        /// </summary>
        [DataMember]
        public bool IsMultivalue { get; set; }

        /// <summary>
        /// System property flag
        /// </summary>
        [DataMember]
        public bool IsSystem { get; set; }

        /// <summary>
        /// Property expression
        /// </summary>
        [DataMember]
        public string Expression { get; set; }

        /// <summary>
        /// Property instance type
        /// </summary>
        [DataMember]
        public string InstanceType { get; set; }

        /// <summary>
        /// Property values
        /// </summary>
        [DataMember]
        public List<InstanceModel> Variants { get; set; }
    }
}