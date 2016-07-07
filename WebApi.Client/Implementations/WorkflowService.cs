// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   WorkflowService.cs
// </summary>
// ***********************************************************************

using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class WorkflowService : BaseService, IWorkflowService
    {
        public WorkflowService(InterfaceInstanceParameters creationParameters)
            : base(creationParameters)
        {
        }

        /// <summary>
        /// Get workflow configuration
        /// </summary>
        /// <param name="id">Workflow identifier</param>
        /// <returns>Workflow model</returns>
        public WorkflowModel Get(string id)
        {
            var query = string.Format("/Api/Workflow/{0}", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<WorkflowModel>(result);
        }
    }
}