using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IItemService
    {
        /// <summary>
        /// Get Item by id
        /// </summary>
        /// <param name="id">Item Identifier</param>
        ItemModel Get(string id);

        /// <summary>
        /// Create Item
        /// </summary>
        /// <param name="id">Container identifier</param>
        /// <param name="properties">Item properties array</param>
        /// <returns>Item identifier</returns>
        string Post(string id, Dictionary<string, IEnumerable<object>> properties);

        /// <summary>
        /// Edit Item
        /// </summary>
        /// <param name="id">Item Identifier</param>
        /// <param name="properties">Array of properties for edit</param>
        void Put(string id, Dictionary<string, IEnumerable<object>> properties);

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id">Item Identifier</param>
        void Delete(string id);

        /// <summary>
        /// Possible assignees for item
        /// </summary>
        /// <param name="id">Item identifier</param>
        IEnumerable<UserModel> Reassign(string id);

        /// <summary>
        /// Reassign Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <param name="user">User identifier</param>
        void Reassign(string id, string user);

        /// <summary>
        /// Possible Transitions for Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        IEnumerable<InstanceModel> Transition(string id);

        /// <summary>
        /// Transition Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <param name="transition">Transition identifier</param>
        void Transition(string id, string transition);

        /// <summary>
        /// Possible Export Templates for Item
        /// </summary>
        /// <param name="id">Item identifier</param>
        IEnumerable<InstanceModel> ExportTemplates(string id);

        /// <summary>
        /// Export Item by Template
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <param name="template">Export Template identifier</param>
        /// <param name="config">Item Export configuration</param>
        FileContent ExportByTemplate(string id, string template, ExportConfig config);

        /// <summary>
        /// Get item history
        /// </summary>
        /// <param name="id">Item identifier</param>
        /// <returns>List of history models</returns>
        IEnumerable<HistoryModel> History(string itemId);
    }
}
