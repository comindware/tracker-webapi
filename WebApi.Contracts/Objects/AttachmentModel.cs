using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class AttachmentModel
    {
        /// <summary>
        /// Attachment identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        //public string ItemId { get; set; } //ToDo

        /// <summary>
        /// Attachment file name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Attachment URI
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Uri { get; set; }

        /// <summary>
        /// Attachment revision identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Revision { get; set; }

        /// <summary>
        /// Attachment creating date
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Attachment image width
        /// </summary>
        [DataMember]
        public int ImageWidth { get; set; }

        /// <summary>
        /// Attachment image height
        /// </summary>
        [DataMember]
        public int ImageHeight { get; set; }

        /// <summary>
        /// Attachment author
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public UserModel Author { get; set; }

        /// <summary>
        /// Attachment type
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Type { get; set; }
    }

    [DataContract]
    public class AttachmentQuery
    {
        /// <summary>
        /// Attachment revision identifier
        /// </summary>
        [DataMember]
        public string RevisionId { get; set; }

        /// <summary>
        /// Attachment identifier
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Item identifier
        /// </summary>
        [DataMember]
        public string ItemId { get; set; }
    }
}
