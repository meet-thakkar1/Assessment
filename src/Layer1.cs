public class Layer1
{
    private readonly ApiClient _client;

    public Layer1(ApiClient client)
    {
        _client = client;
    }

    public async Task Run()
    {
        Console.WriteLine("Layer1 work here");
    }
}