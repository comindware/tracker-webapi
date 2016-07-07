using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IAccountService
    {
        InstanceModel GetCurrentAccount();

        List<FileContent> GetUserAvatars(string[] ids);

        AccountInformation GetProfile(string id);

        DataSet ListAccounts();


    }
}