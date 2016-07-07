using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public class Column
    {
        public string DatasourceId { get; set; }

        public DataType DataType { get; set; }

        public string Name { get; set; }

        public int? Order { get; set; }

        public bool IsMultiValue { get; set; }
    }


    public class Row
    {
        public string Id { get; set; }

        public bool IsRead { get; set; }

        public List<object> Data { get; set; }

        public bool IsExpired { get; set; }
    }


    public class DataSet
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Column> Columns { get; set; }

        public List<Row> Rows { get; set; }
    }
}