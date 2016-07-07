// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   TimespentService.cs
// </summary>
// ***********************************************************************

using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class TimespentService:BaseService,ITimespentService
    {
        public TimespentService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        /// <summary>
        /// Get Timespent record by task id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Timespent record</returns>
        public IEnumerable<TimespentInfoModel> Get(string id)
        {
            var query = string.Format("/Api/Timespent/{0}", id);
            var result = this.ProcessRequest(Method.GET, query);
            return this.GetResponseResult<IEnumerable<TimespentInfoModel>>(result);
        }

        /// <summary>
        /// Create Timespent record
        /// </summary>
        /// <param name="record">Timespent record model</param>
        /// <returns>Timespent record id</returns>
        public string Post(TimespentModel record)
        {
            var query = "/Api/Timespent";
            var result = this.ProcessRequest(Method.POST, query, content: record);
            return this.GetResponseResult<string>(result);
        }

        /// <summary>
        /// Edit Timespent record
        /// </summary>
        /// <param name="id">Timespent record id</param>
        /// <param name="record">Timespent record model</param>
        public void Put(string id, TimespentModel record)
        {
            var query = string.Format("/Api/Timespent/{0}", id);
            var result = this.ProcessRequest(Method.PUT, query, content: record);
            this.GetResponseResult<object>(result);
        }

        /// <summary>
        /// Delete Timespent record
        /// </summary>
        /// <param name="id">Timespent record id</param>
        public void Delete(string id)
        {
            var query = string.Format("/Api/Timespent/{0}", id);
            var result = this.ProcessRequest(Method.DELETE, query);
            this.GetResponseResult<object>(result);
        }
    }
}