using System;
using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    [Serializable]
    public enum FilterCombineType
    {
        AND,
        OR
    }

    [Serializable]
    public abstract class BaseFilter
    {

    }


    [Serializable]
    public class SingleFilter : BaseFilter
    {
        public string DataSourceId { get; set; }
        public object Value { get; set; }
        public FilterType FilterType { get; set; }

    }

    [Serializable]
    public class FilterTree : BaseFilter
    {
        public FilterTree()
        {
            Children = new List<BaseFilter>();
        }

        public FilterCombineType CombinationType { get; set; }
        public List<BaseFilter> Children { get; set; }
    }
}