using System;
using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface ITimespentService
    {
        /// <summary>
        /// Get Timespent record by task id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Timespent record.</returns>
        IEnumerable<TimespentInfoModel> Get(string id);

        /// <summary>
        /// Create Timespent record.
        /// </summary>
        /// <param name="record">Timespent record model.</param>
        /// <returns>Timespent record id.</returns>
        string Post(TimespentModel record);

        /// <summary>
        /// Edit Timespent record.
        /// </summary>
        /// <param name="id">Timespent record id.</param>
        /// <param name="record">Timespent record model.</param>
        void Put(string id, TimespentModel record);

        /// <summary>
        /// Delete Timespent record.
        /// </summary>
        /// <param name="id">Timespent record id.</param>
        void Delete(string id);
    }
}
