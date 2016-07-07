// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   AttachmentService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class AttachmentService: BaseService, IAttachmentService
    {
        public AttachmentService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        /// <summary>
        /// Get attachments by query.
        /// </summary>
        /// <param name="query">Attachment get query.</param>
        /// <returns>Attachment models list.</returns>
        public IEnumerable<AttachmentModel> Get(AttachmentQuery query)
        {
            var queryString = "Api/Attachment";
            var parameters = new Dictionary<string, string>();
            if (query.RevisionId != null)
            {
                parameters["query.revisionId"] = query.RevisionId;
            }
            if (query.Id != null)
            {
                parameters["query.id"] = query.Id;
            }
            if (query.ItemId != null)
            {
                parameters["query.itemId"] = query.ItemId;
            }
            var result = this.ProcessRequest(Method.GET, queryString,parameters);
            return this.GetResponseResult<IEnumerable<AttachmentModel>>(result);
        }

        /// <summary>
        /// Create attachment.
        /// </summary>
        /// <param name="id">Item identifier.</param>
        /// <param name="file">File information.</param>
        public string Post(string id, FileContent file)
        {
            var queryString = string.Format("Api/Attachment/{0}",id);
            var result = this.ProcessFileBodyRequest(Method.POST, queryString, file:file);
            return this.GetResponseResult<string>(result);
        }

        /// <summary>
        /// Get file.
        /// </summary>
        /// <param name="revisionId">File revision identifier.</param>
        /// <returns>Attachment file.</returns>
        public FileContent Content(string revisionId)
        {
            var queryString = string.Format("Api/Attachment/Content/{0}", revisionId);
            var result = this.ProcessRequest(Method.GET, queryString);
            return this.GetResponseFileResult(result);
        }

        /// <summary>
        /// Update attachment.
        /// </summary>
        /// <param name="item"></param>
        public void Put(string item, FileContent file)
        {
            var queryString = string.Format("Api/Attachment/{0}", item);
            var result = this.ProcessFileBodyRequest(Method.PUT, queryString, file: file);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Delete Attachment
        /// </summary>
        /// <param name="query">Delete attachment query.</param>
        public void Delete(AttachmentQuery query)
        {
            var queryString = "Api/Attachment";
            var parameters = new Dictionary<string, string>();
            if (query.RevisionId != null)
            {
                parameters["query.revisionId"] = query.RevisionId;
            }
            if (query.Id != null)
            {
                parameters["query.id"] = query.Id;
            }
            if (query.ItemId != null)
            {
                parameters["query.itemId"] = query.ItemId;
            }
            var result = this.ProcessRequest(Method.DELETE, queryString, parameters);
            this.GetResponseResult<object>(result);
        }
    }
}