public class DatasetResponse
{
    public List<string> Data { get; set; } = new();
    public bool Has_More { get; set; }
    public int Page { get; set; }
    public int Page_Size { get; set; }
    public int Total { get; set; }
}