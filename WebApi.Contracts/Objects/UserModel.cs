using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// User model
    /// </summary>
    [DataContract]
    public class UserModel
    {
        /// <summary>
        /// User identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// User full name
        /// </summary>
        [DataMember]
        public string FullName { get; set; }
    }
}
