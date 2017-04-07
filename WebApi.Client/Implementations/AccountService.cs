using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        public InstanceModel GetCurrentAccount()
        {
            var query = "Api/Account/current";
            var result = ProcessRequest(Method.GET, query);
            return GetResponseResult<AccountInformation>(result);
        }

        public List<FileContent> GetUserAvatars(string[] ids)
        {
            var query = "Api/Account/Avatar";
            var result = ProcessRequest(Method.POST, query, content:ids);
            return GetResponseResult<List<FileContent>>(result);
        }

        public AccountInformation GetProfile(string accountId)
        {
            var query = string.Format("Api/Account/{0}", accountId);
            var result = ProcessRequest(Method.GET, query);
            return GetResponseResult<AccountInformation>(result);
        }

        public DataSet ListAccounts()
        {
            var query = "Api/Account";
            var result = ProcessRequest(Method.GET, query);
            return GetResponseResult<DataSet>(result);
        }
    }
}