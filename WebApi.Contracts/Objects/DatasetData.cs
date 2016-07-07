using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class DatasetData
    {
        [DataMember(IsRequired = true), Required]
        public IEnumerable<PropertyModel> Properties { get; set; }

        [DataMember(IsRequired = true), Required]
        public IEnumerable<Dictionary<string, IEnumerable<object>>> Items { get; set; } 
    }
}
