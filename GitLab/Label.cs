using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GLS.GitLab {

    [DataContract(Name = "label")]
    public class Label {

        #region " Properties "

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "open_issues_count")]
        public int OpenIssues { get; set; }

        [DataMember(Name = "closed_issues_count")]
        public int ClosedIssues { get; set; }

        [DataMember(Name = "open_merge_requests_count")]
        public int OpenMergeRequests { get; set; }

        [DataMember(Name = "priority")]
        public int Priority { get; set; }

        #endregion

    }

}