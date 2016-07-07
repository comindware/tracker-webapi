// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   AppService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class AppService : BaseService, IAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public AppService(InterfaceInstanceParameters creationParameters)
            : base(creationParameters)
        {

        }

        /// <summary>
        /// Get list of all applications
        /// </summary>
        /// <returns>List of App models.</returns>
        public IEnumerable<AppModel> Get()
        {
            var query = "/Api/App";
            var resultRaw = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<AppModel>>(resultRaw);
        }

        /// <summary>
        /// Get application by id
        /// </summary>
        /// <param name="id">Container id.</param>
        /// <returns>App model.</returns>
        public AppModel Get(string id)
        {
            var query = string.Format("/Api/App/{0}", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<AppModel>(result);
        }
    }
}