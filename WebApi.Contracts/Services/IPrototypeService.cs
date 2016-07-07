using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IPrototypeService
    {
        /// <summary>
        /// Get all prototypes
        /// </summary>
        /// <returns>List of prototype models.</returns>
        IEnumerable<PrototypeModel> Get();

        /// <summary>
        /// Get prototype by id
        /// </summary>
        /// <param name="id">Prototype identifier.</param>
        /// <returns>Prototype model.</returns>
        PrototypeModel Get(string id);
    }
}