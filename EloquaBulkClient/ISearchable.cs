namespace EloquaBulkClient
{
    public interface ISearchable
    {
        int page { get; set; }
        int pageSize { get; set; }
        string searchTerm { get; set; }
    }
}
