using EloquaBulkClient.Models.Common;

namespace EloquaBulkClient.Models.Fields
{
    [Resource("/contact/field", "ContactField")]
    public class ContactField : ContractObject, ISearchable
    {
        public string defaultValue { get; set; }
        public string internalName { get; set; }
        public bool? hasReadOnlyConstraint { get; set; }
        public bool? hasNotNullConstraint { get; set; }
        public bool? hasUniquenessConstraint { get; set; }
        public string name { get; set; }
        public string statement { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string searchTerm { get; set; }
    }
}
