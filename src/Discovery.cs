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
            //"/api/v1/health",
            "/api/v1/dataset",
            //"/api/v1/submit",
            // "/api/v1/data",
            // "/api/v1/records",
            // "/api/v1/download",
            // "/api/v1/layer1",
            // "/api/v1/time",
            // "/api/v1/status",
            // "/api/v1/clock",
            // "/api/v1/me",
            // "/api/v1/get",
            // "/api/v1/list",
            // "/api/v1",
            // "/api/v1/",
            // "/api/v1/docs",
            // "/swagger",
            // "/swagger.json",
            // "/openapi.json",
            // "/abcd",
            // "/nnejhf",
            // "/api/v1/abcd",
            // "/api/v1/pqrs",
            // "/api/v2/docs",
            // "/api/v1/submit",
        };

        foreach (var endpoint in endpoints)
        {
            try
            {
                Console.WriteLine(
                    $"\n Checking {endpoint}");

                var result =
                    await _client.GetAsync(endpoint);

                await FileHelper.SaveAsync(
                    $"data/raw/{Sanitize(endpoint)}.txt",
                    result);
                    Console.WriteLine("Result::");
                    Console.WriteLine(result);
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