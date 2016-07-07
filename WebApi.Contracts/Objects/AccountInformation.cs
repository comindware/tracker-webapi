using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{

 
    public class AccountInformation:InstanceModel
    {
        public List<InstanceModel> Subordinates { get; set; }
        public List<InstanceModel> Groups { get; set; }
        public InstanceModel Manager { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }


}