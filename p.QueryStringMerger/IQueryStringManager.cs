namespace p.QueryStringMerger
{
    public interface IQueryStringManager
    {
        string CreateUrl(string url, string queryString);
    }
}