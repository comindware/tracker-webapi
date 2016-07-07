using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IFavoriteService
    {
        /// <summary>
        /// Adds dataset to current user favorites.
        /// </summary>
        /// <param name="id">dataset id.</param>
        void AddToFavorites(string id);

        /// <summary>
        /// Removed dataset from current user favorites.
        /// </summary>
        /// <param name="id">dataset id.</param>
        void RemoveFromFavorites(string id);

        /// <summary>
        /// Gets favorites for current user.
        /// </summary>
        /// <returns>List of favorites.</returns>
        IEnumerable<InstanceModel> GetFavorites();
    }
}