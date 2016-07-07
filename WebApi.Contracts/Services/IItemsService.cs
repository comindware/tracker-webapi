using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IItemsService
    {
        /// <summary>
        /// Get items in dataset
        /// </summary>
        /// <param name="id">Dataset identifier</param>
        /// <param name="rangeSelector">Range selector object</param>
        /// <returns>Array of items</returns>
        DatasetData Get(string id, RangeSelector rangeSelector);

        /// <summary>
        /// Get items by a query
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="rangeSelector">Range selector object</param>
        /// <returns>Array of items</returns>
        DatasetData Query(ItemsQuery query, RangeSelector rangeSelector); 

        /// <summary>
        /// Bulk Create Items
        /// </summary>
        /// <param name="id">Application identifier</param>
        /// <param name="items">List of properties for each item</param>
        BulkOperationResult Post(string id, IEnumerable<Dictionary<string, IEnumerable<object>>> items);

        /// <summary>
        /// Bulk Edit Items
        /// </summary>
        /// <param name="items">Edited items model</param>
        BulkOperationResult Put(IEnumerable<EditItemModel> items);

        /// <summary>
        /// Bulk Delete Items by Dataset identifier
        /// </summary>
        /// <param name="id">Dataset identifier</param>
        BulkOperationResult Delete(string id);

        /// <summary>
        /// Possible Assignees for Items
        /// </summary>
        /// <param name="ids">Items identifiers</param>
        IEnumerable<UserModel> Reassign(string[] ids);

        /// <summary>
        /// Bulk Reassign Items
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="user">User Identifier</param>
        BulkOperationResult Reassign(string[] ids, string user);

        /// <summary>
        /// Bulk Transition Items
        /// </summary>
        /// <param name="ids">Items identifiers</param>
        /// <param name="transition">Transition Identifier</param>
        BulkOperationResult Transition(string[] ids, string transition);
    }
}