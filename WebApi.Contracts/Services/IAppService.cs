using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IAppService
    {
        /// <summary>
        /// Get list of all applications
        /// </summary>
        /// <returns>List of app models</returns>
        IEnumerable<AppModel> Get();

        /// <summary>
        /// Get application by id
        /// </summary>
        /// <param name="id">Container id</param>
        /// <returns>App model</returns>
         AppModel Get(string id);
    }
}