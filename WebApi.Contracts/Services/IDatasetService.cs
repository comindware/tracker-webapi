using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// CMW Tacker Datasets
    /// </summary>
    public interface IDatasetService
    {
        /// <summary>
        /// Get available datasets info by query.
        /// </summary>
        /// <returns>Array of dataset models.</returns>
        IEnumerable<DatasetModel> Get(DatasetsQuery query);

        /// <summary>
        /// Get dataset info by identifier.
        /// </summary>
        /// <param name="id">Dataset identifier.</param>
        /// <returns>Dataset model.</returns>
        DatasetModel Get(string id);

        /// <summary>
        /// Exports dataset to excel query.
        /// </summary>
        /// <param name="datasetId">Dataset id.</param>
        /// <param name="exportConfig"></param>
        /// <returns>Exported file.</returns>
        FileContent Export(string datasetId, ExportConfig exportConfig);
    }
}