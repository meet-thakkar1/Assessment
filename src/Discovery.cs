public class Discovery
{
    private readonly ApiClient _client;

    public Discovery(ApiClient client)
    {
        _client = client;
    }

    public async Task Run()
    {
        var endpoints = new[]
        {
            "/api/v1",
            "/api/v1/",
            "/api/v1/docs",
            "/swagger",
            "/swagger.json",
            "/openapi.json"
        };

        foreach (var endpoint in endpoints)
        {
            try
            {
                Console.WriteLine(
                    $"Checking {endpoint}");

                var result =
                    await _client.GetAsync(endpoint);

                await FileHelper.SaveAsync(
                    $"data/raw/{Sanitize(endpoint)}.txt",
                    result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private string Sanitize(string value)
    {
        return value.Replace("/", "_");
    }
}