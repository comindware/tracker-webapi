using System.Collections.Generic;
using System.Diagnostics;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class DataService:BaseService,IDataService
    {
        public DataService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        public DatasetQuery GetUserConfig(string id)
        {
            var query = "Api/Data/" + id;
            var result= ProcessRequest(Method.GET, query);
            return GetResponseResult<DatasetQuery>(result);
        }

        public void SetUserConfig(DatasetQuery query)
        {
            var address = "Api/Data/"+query.QueryId;
            ProcessRequest(Method.POST, address,content:query);
        }

        public DataSet GetData(DatasetQuery query)
        {
            var address = "Api/Data";
            var result = ProcessRequest(Method.POST, address, content: query);
            return GetResponseResult<DataSet>(result);
        }

        public int GetItemsCount(string id)
        {
            var address = "Api/Data/Count/"+id;
            var result = ProcessRequest(Method.GET, address);
            return GetResponseResult<int>(result);
        }
    }
}