using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IWorkspaceService
    {
        /// <summary>
        /// Get all workspaces
        /// </summary>
        /// <returns>List of workspace models.</returns>
        IEnumerable<WorkspaceModel> Get();

        /// <summary>
        /// Get workspace by id
        /// </summary>
        /// <param name="id">Workspace identifier.</param>
        /// <returns>Workspace model.</returns>
        WorkspaceModel Get(string id);
    }
}