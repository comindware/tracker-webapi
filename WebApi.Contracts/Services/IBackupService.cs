using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public interface IBackupService
    {
        /// <summary>
        /// Start a backup session
        /// </summary>
        /// <param name="config">Session config</param>
        /// <returns>Backup session id</returns>
        BackupSession Create(BackupSessionConfig config);

        /// <summary>
        /// Get backup session
        /// </summary>
        /// <param name="sessionId">ID of backup session</param>
        /// <returns>Backup Session</returns>
        BackupSession Get(string id);

        /// <summary>
        /// Get list of Backup sessions by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List of sessions</returns>
        List<BackupSession> List(BackupSessionFilter filter);

        /// <summary>
        /// Stop backup session
        /// </summary>
        /// <param name="id">Session id</param>
        /// <returns>Stopped backup session</returns>
        BackupSession Abort(string id);
    }
}