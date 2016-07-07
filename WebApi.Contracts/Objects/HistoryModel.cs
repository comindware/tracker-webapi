using System;
using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
    public class HistoryModel
    {
        public string Id { get; set; }

        public DateTime? Date { get; set; }

        public UserModel Author { get; set; }

        public string ContainerId { get; set; }

        public string Event { get; set; }

        public string EventGroup { get; set; }

        public string RecordAuthor { get; set; }

        public string RecordContainer { get; set; }

        public DateTime RecordDate { get; set; }

        public string RecordEvent { get; set; }

        public string RecordSubjectId { get; set; }

        public InstanceModel Subject { get; set; }

        public string[] SubjectSystemType { get; set; }

        public string SubjectUserType { get; set; }

        public ICollection<HistoryChangeItemModel> Changes { get; set; }
    }

    public class HistoryChangeItemModel
    {
        public string Id { get; set; }

        public string Predicate { get; set; }

        public string PredicateType { get; set; }

        public string PredicateName { get; set; }

        public HashSet<HistoryChangedChangeModel> OldObjectRef { get; set; }

        public HashSet<HistoryChangedChangeModel> NewObjectRef { get; set; }
    }

    public class HistoryChangedChangeModel
    {
        public string Id { get; set; }

        public string ObjectId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string File { get; set; }

        public DateTime? Date { get; set; }
    }
}
