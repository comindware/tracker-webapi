// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   PrototypeService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class PrototypeService:BaseService, IPrototypeService
    {
        public PrototypeService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        /// <summary>
        /// Get all prototypes
        /// </summary>
        /// <returns>List of prototype models.</returns>
        public IEnumerable<PrototypeModel> Get()
        {
            var query = "/Api/Prototype";
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<PrototypeModel>>(result);
        }

        /// <summary>
        /// Get prototype by id
        /// </summary>
        /// <param name="id">Prototype identifier.</param>
        /// <returns>Prototype model.</returns>
        public PrototypeModel Get(string id)
        {
            var query = string.Format("/Api/Prototype/{0}",id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<PrototypeModel>(result);
        }
    }
}