
    using System;
    using System.Collections.Generic;
    using System.Linq;

namespace Comindware.Platform.WebApi.Contracts
{
    public enum DataFormat
    {
        Undefined,

        #region DateTime

        /// <summary>
        /// 6/15/2009
        /// </summary>
        ShortDate,

        /// <summary>
        /// 2005-08-09
        /// </summary>
        DateISO,

        /// <summary>
        /// Jun. 15, 2009
        /// </summary>
        CondensedDate,

        /// <summary>
        /// Monday, June 15, 2009
        /// </summary>
        LongDate,

        /// <summary>
        /// June 15
        /// </summary>
        MonthDay,

        /// <summary>
        /// June, 2009
        /// </summary>
        YearMonth,

        /// <summary>
        /// Monday, June 15, 2009 1:45 PM
        /// </summary>
        FullDateShortTime,

        /// <summary>
        /// Monday, June 15, 2009 1:45:30 PM
        /// </summary>
        FullDateLongTime,

        /// <summary>
        /// 6/15/2009 1:45 PM
        /// </summary>
        GeneralDateShortTime,

        /// <summary>
        /// 6/15/2009 1:45:30 PM
        /// </summary>
        GeneralDateLongTime,

        /// <summary>
        /// Jun. 15, 2009 1:45 PM
        /// </summary>
        CondensedDateTime,

        /// <summary>
        /// 1:45 PM
        /// </summary>
        ShortTime,

        /// <summary>
        /// 1:45:30 PM
        /// </summary>
        LongTime,

        /// <summary>
        /// 2005-08-09T18:31:42+03:30
        /// </summary>
        DateTimeISO,

        #endregion
    }

    public enum FilterType
    {
        Equals,
        LesserThan,
        GreaterThan,
        Like
    }

    public class FilterItem
    {
        private object value;

        public FilterType FilterType { get; set; }

        public object Value
        {
            get { return this.value; }
            set
            {
                var types = new[] {typeof (double), typeof (int), typeof (long), typeof (float), typeof (byte)};
                if (value != null)
                {
                    var type = value.GetType();
                    this.value = types.Contains(type) ? Convert.ToDecimal(value) : value;
                }
                else
                {
                    this.value = null;
                }


            }
        }
    }

    public class GlobalFilterItem : FilterItem
    {
        public string DatasourceId { get; set; }
    }



    public class DatasetQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DatasetQuery()
        {
           
        }

        public string QueryId { get; set; }

        public string Name { get; set; }

        public Paging Paging { get; set; }

        public FilterTree FilterTree { get; set; }

        public List<Column> Columns { get; set; }

        public SortingSettings Sorting { get; set; }


    }

    public class Paging
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }

    /// <summary>
    /// Configuration of sorting in dataset.
    /// </summary>
    public class SortingSettings
    {
        /// <summary>
        /// Id of the field we sort by.
        /// </summary>
        public string DatasourceId { get; set; }

        /// <summary>
        /// Direction in which we sort by (ascending or descending).
        /// </summary>
        public SortDirection Direction { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", DatasourceId, Direction);
        }
    }

}
