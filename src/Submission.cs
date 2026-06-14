using System.Text;
using System.Text.Json;

public class Submission
{
    private readonly ApiClient _client;

    public Submission(ApiClient client)
    {
        _client = client;
    }

    public async Task Submit(
        string type,
        string value,
        string notes = "")
    {
        string endpoint="/api/v1/submit";
        var payload = new
        {
            type,
            value,
            notes
        };

        var json =
            JsonSerializer.Serialize(payload);

        var content =
            new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

        var result =
            await _client.PostAsync(endpoint, content);

        Console.WriteLine(result);  
    }
}