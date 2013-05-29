using System;
using EloquaBulkClient.Models.Common;

namespace EloquaBulkClient.Models.Filters
{
    [Resource("/contact/filter", "ContactFilter")]
    public class ContactFilter : ContractObject, ISearchable
    {
        public int? count { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdAt { get; set; }
        public string name { get; set; }
        public DateTime? executedAt { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string uri { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string searchTerm { get; set; }
    }
}
