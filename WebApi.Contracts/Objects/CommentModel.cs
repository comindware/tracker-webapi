using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class CommentModel : IComparable<CommentModel>, IComparable
    {
        /// <summary>
        /// Comment identifier
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Id { get; set; }

        /// <summary>
        /// Comment value.
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Comment creation date
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Comment parent identifier
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// Comment author
        /// </summary>
        [DataMember]
        public UserModel Author { get; set; }

        /// <summary>
        /// Comment children tree
        /// </summary>
        [DataMember]
        public SortedSet<CommentModel> Children { get; set; }

        public int CompareTo(CommentModel other)
        {
            if (other == null)
            {
                return 1;
            }

            return -this.Date.CompareTo(other.Date);
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as CommentModel);
        }
    }
}
