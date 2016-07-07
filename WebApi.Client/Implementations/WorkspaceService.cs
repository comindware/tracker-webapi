// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   WorkspaceService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class WorkspaceService: BaseService, IWorkspaceService
    {
        public WorkspaceService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        /// <summary>
        /// Get all workspaces
        /// </summary>
        /// <returns>List of workspace models</returns>
        public IEnumerable<WorkspaceModel> Get()
        {
            var query = string.Format("/Api/Workspace");
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<WorkspaceModel>>(result);
        }

        /// <summary>
        /// Get workspace by id
        /// </summary>
        /// <param name="id">Workspace identifier</param>
        /// <returns>Workspace model</returns>
        public WorkspaceModel Get(string id)
        {
            var query = string.Format("/Api/Workspace/{0}", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<WorkspaceModel>(result);
        }
    }
}