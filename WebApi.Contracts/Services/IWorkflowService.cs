namespace Comindware.Platform.WebApi.Contracts
{
    public interface IWorkflowService
    {
        /// <summary>
        /// Get workflow configuration.
        /// </summary>
        /// <param name="id">Workflow identifier.</param>
        /// <returns>Workflow model.</returns>
        WorkflowModel Get(string id);
    }
}
