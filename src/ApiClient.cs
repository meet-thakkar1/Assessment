using System.Net.Http.Headers;

public class ApiClient
{
    private readonly HttpClient _client;

    public ApiClient()
    {
        _client = new HttpClient();

        _client.BaseAddress =
            new Uri(Config.BaseUrl);

        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                Config.ApiKey);
    }

    public async Task<string> GetAsync(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);

        await LogResponse(response);

        return await response.Content.ReadAsStringAsync();
    }
public async Task<string> SendAsync(string endpoint)
    {
        var request = new HttpRequestMessage(
    HttpMethod.Options,
    endpoint);
        var response = await _client.SendAsync(request);

        await LogResponse(response);

        return await response.Content.ReadAsStringAsync();
    }
    public async Task<string> PostAsync(
        string endpoint,
        HttpContent content)
    {
        var response =
            await _client.PostAsync(endpoint, content);

        await LogResponse(response);

        return await response.Content.ReadAsStringAsync();
    }

    private async Task LogResponse(HttpResponseMessage response)
    {
        Console.WriteLine(
            $"{(int)response.StatusCode} {response.StatusCode}");

        foreach (var h in response.Headers)
        {
            Console.WriteLine(
                $"{h.Key}: {string.Join(",", h.Value)}");
        }

        var body =
            await response.Content.ReadAsStringAsync();

        Directory.CreateDirectory("data/logs");

        await File.AppendAllTextAsync(
            "data/logs/http.log",
            $"\n[{DateTime.UtcNow}]\n{body}\n");
    }
}