// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   ItemService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Globalization;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class ItemService: BaseService, IItemService
    {
        public ItemService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        /// <summary>
        /// Get Item by id
        /// </summary>
        /// <param name="id">Item Identifier</param>
        /// <returns>Item model</returns>
        public ItemModel Get(string id)
        {
            var query = string.Format("/Api/Item/{0}", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<ItemModel>(result);
        }

        /// <summary>
        /// Create Item
        /// </summary>
        /// <param name="id">Container identifier</param>
        /// <param name="properties">Item properties dictionary</param>
        /// <returns>Item identifier</returns>
        public string Post(string id, Dictionary<string, IEnumerable<object>> properties)
        {
            var query = string.Format("/Api/Item/{0}", id);
            var result = this.ProcessRequest(Method.POST, query, content: properties);
            return this.GetResponseResult<string>(result);
        }

        /// <summary>
        /// Edit Item
        /// </summary>
        /// <param name="id">Item Identifier</param>
        /// <param name="properties">Edited properties dictionary</param>
        public void Put(string id, Dictionary<string, IEnumerable<object>> properties)
        {
            var query = string.Format("/Api/Item/{0}", id);
            var result = this.ProcessRequest(Method.PUT, query, content: properties);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id">Item Identifier</param>
        public void Delete(string id)
        {
            var query = string.Format("/Api/Item/{0}", id);
            var result = this.ProcessRequest(Method.DELETE, query);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Possible assignees for item
        /// </summary>
        /// <param name="id">Item identifier</param>
        public IEnumerable<UserModel> Reassign(string id)
        {
            var query = string.Format("/Api/Item/{0}/Reassign", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<UserModel>>(result);
        }

        /// <summary>
        /// Reassign Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <param name="user">User identifier</param>
        public void Reassign(string id, string user)
        {
            var query = string.Format("/Api/Item/{0}/Reassign/{1}", id, user);
            var result = this.ProcessRequest(Method.POST, query);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Possible Transitions for Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <returns>List of instance models consisting of Transition identifier and Transition name</returns>
        public IEnumerable<InstanceModel> Transition(string id)
        {
            var query = string.Format("/Api/Item/{0}/Transition", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<InstanceModel>>(result);
        }

        /// <summary>
        /// Transition Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <param name="transition">Transition identifier</param>
        public void Transition(string id, string transition)
        {
            var query = string.Format("/Api/Item/{0}/Transition/{1}", id, transition);
            var result = this.ProcessRequest(Method.POST, query);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Possible Export Templates for Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <returns>List of instance models consisting of Export template id and Export template name</returns>
        public IEnumerable<InstanceModel> ExportTemplates(string id)
        {
            var query = string.Format("/Api/Item/{0}/ExportTemplates", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<InstanceModel>>(result);
        }

        /// <summary>
        /// Export Item by Template
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <param name="template">Export Template identifier</param>
        /// <param name="config">Item Export configuration</param>
        /// <returns>Exported file</returns>
        public FileContent ExportByTemplate(string id, string template, ExportConfig config)
        {
            var query = string.Format("/Api/Item/{0}/ExportByTemplate/{1}", id,template);

            Dictionary<string, string> queryParameters = null;
            if(config.TimeZone != null)
            {
                queryParameters = new Dictionary<string, string>
                {
                    {"timeZone", config.TimeZone.Value.ToString(CultureInfo.InvariantCulture)}
                };
            }

            var result = this.ProcessRequest(Method.GET, query, queryParameters);

            return this.GetResponseFileResult(result);
        }

        /// <summary>
        /// Get item history.
        /// </summary>
        /// <param name="itemId">Item identifier</param>
        /// <returns>List of history models</returns>
        public IEnumerable<HistoryModel> History(string itemId)
        {
            var query = "/Api/Item/History/" + itemId;
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<HistoryModel>>(result);
        }
    }
}