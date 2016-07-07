using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IAttachmentService
    {
        /// <summary>
        /// Get attachments by query.
        /// </summary>
        /// <param name="query">Attachment get query.</param>
        /// <returns>Attachment models list.</returns>
         IEnumerable<AttachmentModel> Get(AttachmentQuery query);

        /// <summary>
        /// Create attachments.
        /// </summary>
        /// <param name="id">Item identifier.</param>
         string Post(string id, FileContent file);

        /// <summary>
        /// Get file.
        /// </summary>
        /// <param name="revisionId">File revision identifier.</param>
        /// <returns>Attachment file.</returns>
        FileContent Content(string revisionId);

        /// <summary>
        /// Update attachment.
        /// </summary>
        /// <param name="id">Attachment identifier</param>
        void Put(string id, FileContent file);

        /// <summary>
        /// Delete Attachment
        /// </summary>
        /// <param name="query">Delete attachment query.</param>
        void Delete(AttachmentQuery query);
    }
}
