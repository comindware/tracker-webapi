using System;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class TimespentInfoModel : TimespentModel
    {
        /// <summary>
        /// Record identifier
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Id { get; set; }

        /// <summary>
        /// Timespent submitter
        /// </summary>
        [DataMember(IsRequired = true)]
        public UserModel Submitter { get; set; }

        /// <summary>
        /// Task for timespent submission
        /// </summary>
        [DataMember(IsRequired = true)]
        public InstanceModel Task { get; set; }
    }

    [DataContract]
    public class TimespentModel
    {
        /// <summary>
        /// Time spent value
        /// </summary>
        [DataMember(IsRequired = true)]
        public TimeSpan Timespent { get; set; }

        /// <summary>
        /// Record creation date
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Description of the timespent
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Id of a task for timespent submission
        /// </summary>
        [DataMember(IsRequired = true)]
        public string TaskId { get; set; }
    }
}
