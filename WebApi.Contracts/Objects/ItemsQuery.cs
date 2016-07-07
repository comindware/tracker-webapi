using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Items Query Parameters
    /// </summary>
    [DataContract]
    public class ItemsQuery
    {
        /// <summary>
        /// Expression for querying
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string Expression { get; set; }

        /// <summary>
        /// Column for sorting
        /// </summary>
        [DataMember]
        public string SortByColumn { get; set; }

        /// <summary>
        /// Sort Direction
        /// </summary>
        [DataMember]
        public SortDirection? SortDirection { get; set; }

        /// <summary>
        /// Item's properties
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public List<string> Properties { get; set; }
    }

    [DataContract]
    public class RangeSelector
    {
        /// <summary>
        /// Items to skip (0 by default)
        /// </summary>
        [DataMember]
        public int Skip { get; private set; }

        /// <summary>
        /// Items to take (100 by default)
        /// </summary>
        [DataMember]
        public int Take { get; private set; }

        public RangeSelector(int? skip, int? take)
        {
            if (skip == null)
            {
                this.Skip = 0;
            }
            else
            {
                if (skip < 0)
                {
                    throw new ArgumentException();
                }

                this.Skip = (int)skip;
            }

            if (take == null)
            {
                this.Take = 100;
            }
            else
            {
                if (take < 0)
                {
                    throw new ArgumentException();
                }

                this.Take = (int)take;
            }
        }
    }
}