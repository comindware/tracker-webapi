namespace Comindware.Platform.WebApi.Contracts
{
    public interface IDataService
    {
        /// <summary>
        /// Gets dataset config
        /// </summary>
        /// <param name="id">Dataset identifier</param>
        /// <returns>Dataset config.</returns>
        DatasetQuery GetUserConfig(string id);

        /// <summary>
        /// Sets dataset config
        /// </summary>
        /// <param name="query">Dataset config</param>
        void SetUserConfig(DatasetQuery query);

        /// <summary>
        /// Gets dataset data by config
        /// </summary>
        /// <param name="query">Dataset config</param>
        /// <returns>Dataset data.</returns>
        DataSet GetData(DatasetQuery query);

        /// <summary>
        /// Gets overall items count in dataset
        /// </summary>
        /// <param name="id">Dataset id</param>
        /// <returns>Items count.</returns>
        int GetItemsCount(string id);
    }
}
