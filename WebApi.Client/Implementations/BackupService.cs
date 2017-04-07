using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class BackupService : BaseService, IBackupService
    {
        public BackupService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        public BackupSession Create(BackupSessionConfig config)
        {
            var query = "Api/Backup";
            var result = ProcessRequest(Method.POST, query, content: config);
            return GetResponseResult<BackupSession>(result);
        }

        public BackupSession Get(string id)
        {
            var query = string.Format("Api/Backup/{0}", id);
            var result = ProcessRequest(Method.GET, query);
            return GetResponseResult<BackupSession>(result);
        }

        public List<BackupSession> List(BackupSessionFilter filter)
        {
            var parameters = new Dictionary<string, List<string>>();
            if (filter.EnqueueFromDate.HasValue)
            {
                parameters["query.enqueueFromDate"] = new List<string> { filter.EnqueueFromDate.Value.ToString() };
            }
            if (filter.EnqueueToDate.HasValue)
            {
                parameters["query.enqueueToDate"] = new List<string> { filter.EnqueueToDate.Value.ToString() };
            }
            if (filter.StatusCode != null)
            {
                var statusCodes = new List<string>();
                foreach (var code in filter.StatusCode)
                {
                    statusCodes.Add(code.ToString());
                }
                parameters["query.statusCode"] = statusCodes;
            }
            var query = "Api/Backup";
            var result = ProcessRequest(Method.GET, query, parameters);
            return GetResponseResult<List<BackupSession>>(result);
        }

        public BackupSession Abort(string id)
        {
            var query = string.Format("Api/Backup/{0}", id);
            var result = ProcessRequest(Method.DELETE, query);
            return GetResponseResult<BackupSession>(result);
        }
    }
}
