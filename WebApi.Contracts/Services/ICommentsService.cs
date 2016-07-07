namespace Comindware.Platform.WebApi.Contracts
{
    public interface ICommentsService
    {
        /// <summary>
        /// Get comments tree.
        /// </summary>
        /// <param name="id">item identifier.</param>
        /// <returns>Comment tree model.</returns>
        CommentModel Get(string id);

        /// <summary>
        /// Create new comment.
        /// </summary>
        /// <param name="id">Comment parent identifier.</param>
        /// <param name="value">Comment value.</param>
        /// <returns>New comment identifier.</returns>
        string Post(string id, string value);

        /// <summary>
        /// Edit comment.
        /// </summary>
        /// <param name="id">Comment identifier.</param>
        /// <param name="value">Comment value.</param>
        void Put(string id, string value);

        /// <summary>
        /// Delete comment.
        /// </summary>
        /// <param name="id">Comment id.</param>
        void Delete(string id);
    }
}
