using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Comindware.Platform.WebApi.Contracts
{
    [DataContract]
    public class BackupSessionConfig
    {
        /// <summary>
        /// Backup folder location
        /// </summary>
        [DataMember]
        public string Path { get; set; }

        /// <summary>
        /// Backup file name
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Archieve backup flag
        /// </summary>
        [DataMember]
        public bool? Archive { get; set; }

        /// <summary>
        /// Overwrite existing files flag
        /// </summary>
        [DataMember]
        public bool? Overwrite { get; set; }
    }

    [DataContract]
    public class BackupSession
    {
        /// <summary>
        /// Backup session identifier
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        
        /// <summary>
        /// User started backup session
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// Backup session creation date
        /// </summary>
        [DataMember]
        public DateTime? EnqueueDate { get; set; }

        /// <summary>
        /// Backup starting date
        /// </summary>
        [DataMember]
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// Backup comletion date
        /// </summary>
        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Backup session status code
        /// </summary>
        [DataMember]
        public BackupStatus StatusCode { get; set; }

        /// <summary>
        /// Input parameters
        /// </summary>
        [DataMember]
        public string InputParameters { get; set; }
    }

    [DataContract]
    public class BackupSessionFilter
    {
        /// <summary>
        /// Status code applied for filtering
        /// </summary>
        [DataMember]
        public List<BackupStatus> StatusCode { get; set; }

        /// <summary>
        /// Set lower border for filtering by Enqueued date
        /// </summary>
        [DataMember]
        public DateTime? EnqueueFromDate { get; set; }

        /// <summary>
        /// Set higher border for filtering by Enqueued date
        /// </summary>
        [DataMember]
        public DateTime? EnqueueToDate { get; set; }
    }

    public enum BackupStatus
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// Session is in queue
        /// </summary>
        OkQue,
        /// <summary>
        /// Session is in progress
        /// </summary>
        OkInp,
        /// <summary>
        /// Session finished
        /// </summary>
        OkFin,
        /// <summary>
        /// Session was finished by user before completion
        /// </summary>
        OkTerm,
        /// <summary>
        /// Failed due to max sessions count in queue
        /// </summary>
        ErrQue,
        /// <summary>
        /// Required parameter "Archive" missing
        /// </summary>
        ErrParArh,
        /// <summary>
        /// Missing required parameter "Overwrite" missing
        /// </summary>
        ErrParRew,
        /// <summary>
        /// Missing required parameter "FileName" 
        /// </summary>
        ErrParFnam,
        /// <summary>
        /// Missing required parameter "Path" 
        /// </summary>
        ErrParFol,
        /// <summary>
        /// Unknown error
        /// </summary>
        ErrOth,
        /// <summary>
        /// Session not found
        /// </summary>
        ErrSesNF,
        /// <summary>
        /// File with that name already exists
        /// </summary>
        ErrFilRew,
        /// <summary>
        /// Have no access to file
        /// </summary>
        ErrFilAcc,
        /// <summary>
        /// Folder not found
        /// </summary>
        ErrFolName,
        /// <summary>
        /// Incorrect file name
        /// </summary>
        ErrFilName,
        /// <summary>
        /// Have no access to folder
        /// </summary>
        ErrFolAcc
    }

    public static class BackupStatusExtensions
    {
        public static string ToClientString(this BackupStatus status)
        {
            switch (status)
            {
                case BackupStatus.OkQue:
                    return "Session is in queue";
                case BackupStatus.OkInp:
                    return "Session is in progress";
                case BackupStatus.OkFin:
                    return "Session finished";
                case BackupStatus.OkTerm:
                    return "Session was finished by user before completion";
                case BackupStatus.ErrQue:
                    return "Failed due to max sessions count in queue";
                case BackupStatus.ErrParArh:
                    return "Required parameter 'Archive' missing";
                case BackupStatus.ErrParRew:
                    return "Missing required parameter'Overwrite' missing";
                case BackupStatus.ErrParFnam:
                    return "Missing required parameter 'FileName'";
                case BackupStatus.ErrParFol:
                    return "Missing required parameter 'Path'";
                case BackupStatus.ErrOth:
                    return "Unknown error";
                case BackupStatus.ErrSesNF:
                    return "Session not found";
                case BackupStatus.ErrFilRew:
                    return "File with that name already exists";
                case BackupStatus.ErrFilAcc:
                    return "Have no access to file";
                case BackupStatus.ErrFolName:
                    return "Folder not found";
                case BackupStatus.ErrFilName:
                    return "Incorrect file name";
                case BackupStatus.ErrFolAcc:
                    return "Have no access to folder";
                case BackupStatus.Undefined:
                default:
                    return "Undefined";
            }
        }
    }
}