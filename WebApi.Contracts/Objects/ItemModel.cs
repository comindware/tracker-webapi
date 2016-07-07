using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    public enum ItemKind
    {
        /// <summary>
        /// Tasks are pieces of work that need to get done. 
        /// They are parts of a project, or components of a day. 
        /// They can exist on their own or they can be part of a larger picture with subtasks or workflows. 
        /// You can assign them to yourself or to members of your team, and with Comindware Tracker, you can track their status automatically.
        /// </summary>
        Task,

        /// <summary>
        /// You can create and manage libraries of the same documents, for example, a wiki library that will contain wiki articles, a spec library that will contain specifications for a product.
        /// </summary>
        Document,

        /// <summary>
        /// Suppose you have tasks that are part of a process. 
        /// How would you push tasks through a sequence or automatically generate tasks based on where a project stands? 
        /// In Comindware Tracker, you do this by creating a “ Workflow Task.” 
        /// Examples of workflow tasks are change requests, 
        /// help desk tickets, claims, product bugs, employee records, essentially any process that you want to be moved along and tracked.
        /// </summary>
        Tracker
    }

    /// <summary>
    /// Item model
    /// </summary>
    [DataContract]
    public class ItemModel
    {
        /// <summary>
        /// Item identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Application identifier that contains this item
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Application { get; set; }

        /// <summary>
        /// Item prototype identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Prototype { get; set; }

        /// <summary>
        /// Item type
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public ItemKind Type { get; set; }

        /// <summary>
        /// Item creator user model
        /// </summary>
        [DataMember]
        public UserModel Creator { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Last modified date
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Item's properties
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public Dictionary<string, IEnumerable<object>> Properties { get; set; }
    }

    /// <summary>
    /// Sort Direction
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// Ascending.
        /// </summary>
        Asc,

        /// <summary>
        /// Descending.
        /// </summary>
        Desc
    }

    public class EditItemModel
    {
        /// <summary>
        /// Item identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string ItemId { get; set; }

        /// <summary>
        /// Item's properties list
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public Dictionary<string, IEnumerable<object>> Properties { get; set; }
    }
}
