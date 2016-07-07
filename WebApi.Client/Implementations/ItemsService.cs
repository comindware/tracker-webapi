// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   ItemsService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class ItemsService : BaseService, IItemsService
    {
        public ItemsService(InterfaceInstanceParameters creationParameters)
            : base(creationParameters)
        {
        }

        /// <summary>
        /// Get items in dataset.
        /// </summary>
        /// <param name="id">Dataset identifier.</param>
        /// <param name="rangeSelector">Range selector object.</param>
        /// <returns>Array of items</returns>
        public DatasetData Get(string id, RangeSelector rangeSelector)
        {
            var queryString = string.Format("Api/Items/{0}", id);
            var parameters = new Dictionary<string, string>();
            parameters["rangeSelector.skip"] = rangeSelector.Skip.ToString();
            parameters["rangeSelector.take"] = rangeSelector.Take.ToString();
            var result = this.ProcessRequest(Method.GET, queryString, parameters);
            return this.GetResponseResult<DatasetData>(result);
        }

        /// <summary>
        /// Get items by a query.
        /// </summary>
        /// <param name="query">Query object.</param>
        /// <param name="rangeSelector">Range selector object.</param>
        /// <returns>Array of items.</returns>
        public DatasetData Query(ItemsQuery query, RangeSelector rangeSelector)
        {
            var queryString = "Api/Items/Query";
            var parameters = new Dictionary<string, string>();
            if (rangeSelector != null)
            {
                parameters["rangeSelector.skip"] = rangeSelector.Skip.ToString();
                parameters["rangeSelector.take"] = rangeSelector.Take.ToString();
            }
            var result = this.ProcessRequest(Method.POST, queryString, parameters, query);
            return this.GetResponseResult<DatasetData>(result);

        }

        /// <summary>
        /// Bulk Create Items
        /// </summary>
        /// <param name="id">Application identifier</param>
        /// <param name="items">List of properties for each item</param>
        /// <returns>Bulk operation result object</returns>
        public BulkOperationResult Post(string id, IEnumerable<Dictionary<string, IEnumerable<object>>> items)
        {
            var queryString = string.Format("Api/Items/{0}", id);
            var result = this.ProcessRequest(Method.POST, queryString, content: items);
            return this.GetResponseResult<BulkOperationResult>(result);
        }

        /// <summary>
        /// Bulk Edit Items
        /// </summary>
        /// <param name="items">Edited items model</param>
        /// <returns>Bulk operation result object</returns>
        public BulkOperationResult Put(IEnumerable<EditItemModel> items)
        {
            var queryString = "Api/Items";
            var result = this.ProcessRequest(Method.PUT, queryString, content: items);
            return this.GetResponseResult<BulkOperationResult>(result); 
        }

        /// <summary>
        /// Bulk Delete Items by Dataset identifier
        /// </summary>
        /// <param name="id">Dataset identifier</param>
        public BulkOperationResult Delete(string id)
        {
            var queryString = "Api/Items/" + id;
            var result = this.ProcessRequest(Method.DELETE, queryString);
            return GetResponseResult<BulkOperationResult>(result);
        }

        /// <summary>
        /// Possible Assignees for Items
        /// </summary>
        /// <param name="ids">Items identifiers.</param>
        /// <returns>List of User models</returns>
        public IEnumerable<UserModel> Reassign(string[] ids)
        {
            var queryString = "Api/Items/Bulk/Reassign";

            var result = this.ProcessRequest(Method.GET, queryString, new Dictionary<string, string>()
            {
                {"ids",string.Join(",",ids)}
            });
            return GetResponseResult<IEnumerable<UserModel>>(result);
        }

        /// <summary>
        /// Bulk Reassign Items
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="user">User Identifier</param>
        /// <returns>Bulk operation result object</returns>
        public BulkOperationResult Reassign(string[] ids, string user)
        {
            var queryString = string.Format("Api/Items/Bulk/Reassign/{0}", user);

            var result = this.ProcessRequest(Method.POST, queryString, content:ids);
            return GetResponseResult<BulkOperationResult>(result);
        }

        /// <summary>
        /// Bulk Transition Items
        /// </summary>
        /// <param name="ids">Items identifiers</param>
        /// <param name="transition">Transition Identifier</param>
        /// <returns>Bulk operation result object</returns>
        public BulkOperationResult Transition(string[] ids, string transition)
        {
            var queryString = string.Format("Api/Items/Bulk/Transition/{0}", transition);
            var result = this.ProcessRequest(Method.POST, queryString, content: ids);
            return GetResponseResult<BulkOperationResult>(result);
        }
    }
}