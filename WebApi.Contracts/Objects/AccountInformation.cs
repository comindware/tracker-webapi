using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class AccountInformation : InstanceModel
    {
        [DataMember]
        public List<InstanceModel> Subordinates { get; set; }

        [DataMember]
        public List<InstanceModel> Groups { get; set; }

        [DataMember]
        public InstanceModel Manager { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}