// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   ICommentsService.cs
// </summary>
// ***********************************************************************

using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class CommentsService : BaseService, ICommentsService
    {
        public CommentsService(InterfaceInstanceParameters creationParameters)
            : base(creationParameters)
        {
        }

        /// <summary>
        /// Get comments tree.
        /// </summary>
        /// <param name="id">item identifier.</param>
        /// <returns>Comment tree model.</returns>
        public CommentModel Get(string id)
        {
            var query = string.Format("Api/Comment/{0}", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<CommentModel>(result);
        }

        /// <summary>
        /// Create new comment.
        /// </summary>
        /// <param name="id">Comment parent identifier.</param>
        /// <param name="value">Comment value.</param>
        /// <returns>New comment identifier.</returns>
        public string Post(string id, string value)
        {
            var query = string.Format("Api/Comment/{0}", id);
            var result = this.ProcessRequest(Method.POST, query, content: value);
            return this.GetResponseResult<string>(result);
        }

        /// <summary>
        /// Edit comment.
        /// </summary>
        /// <param name="id">Comment identifier.</param>
        /// <param name="value">Comment value.</param>
        public void Put(string id, string value)
        {
            var query = string.Format("Api/Comment/{0}", id);
            var result = this.ProcessRequest(Method.PUT, query, content: value);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Delete comment.
        /// </summary>
        /// <param name="id">Comment id.</param>
        public void Delete(string id)
        {
            var query = string.Format("Api/Comment/{0}", id);
            var result = this.ProcessRequest(Method.DELETE, query);
            this.GetResponseResult<object>(result);
        }
    }
}