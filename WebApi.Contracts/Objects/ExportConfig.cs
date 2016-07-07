using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class ExportConfig
    {
        /// <summary>
        /// TimeZone offset.
        /// </summary>
        [DataMember]
        public double? TimeZone { get; set; }
    }
}