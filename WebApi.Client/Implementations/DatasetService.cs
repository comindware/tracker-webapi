// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   DatasetService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class DatasetService:BaseService,IDatasetService
    {
        public DatasetService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        /// <summary>
        /// Get available datasets info by query.
        /// </summary>
        /// <returns>Array of dataset models.</returns>
        public IEnumerable<DatasetModel> Get(DatasetsQuery query)
        {
            var ids = string.Join(",", query.Ids ?? new string[0]);
      
            var queryString = string.Format("/Api/Dataset");
            var queryParameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                queryParameters["ids"] = ids;
            }

            if (!string.IsNullOrWhiteSpace(query.ApplicationId))
            {
                queryParameters["applicationId"] = query.ApplicationId;
            }

            var result = this.ProcessRequest(Method.GET, queryString, queryParameters);
            return this.GetResponseResult<IEnumerable<DatasetModel>>(result);
        }

        /// <summary>
        /// Get dataset info by identifier.
        /// </summary>
        /// <param name="id">Dataset identifier.</param>
        /// <returns>Dataset model.</returns>
        public DatasetModel Get(string id)
        {
            var queryString = string.Format("/Api/Dataset/{0}",id);
            var queryParameters = new Dictionary<string, string>();        
            var result = this.ProcessRequest(Method.GET, queryString, queryParameters);
            return this.GetResponseResult<DatasetModel>(result);
        }

        /// <summary>
        /// Exports dataset to excel query.
        /// </summary>
        /// <param name="datasetId">Dataset id.</param>
        /// <param name="exportConfig"></param>
        /// <returns>Exported file.</returns>
        public FileContent Export(string datasetId, ExportConfig exportConfig = null)
        {
            var queryString = string.Format("/Api/Dataset/{0}/Export", datasetId);
            var queryParameters = new Dictionary<string, string>();
            if (exportConfig != null && exportConfig.TimeZone.HasValue)
            {
                queryParameters["config.timeZone"] = exportConfig.TimeZone.Value.ToString();
            }
            var result = this.ProcessRequest(Method.GET, queryString, queryParameters);
            return this.GetResponseFileResult(result);
        }

     
    }
}