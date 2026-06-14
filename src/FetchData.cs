using System.Text;

public class FetchData
{
    private readonly ApiClient _client;

    public FetchData(ApiClient client)
    {
        _client = client;
    }

    public async Task Run()
    {
        var endpoints = new[]
        {
            "/api/v1/dataset",
        };

        foreach (var endpoint in endpoints)
        {
            try
            {
            for(int i=1;i<6;i++){
 
                Console.WriteLine(
                    $"\n Checking {endpoint}");

                var result =
                    await _client.GetAsync(endpoint+"?page="+i+"&&page_size=100");

                await FileHelper.SaveAsync(
                    $"data/raw/page{i}.json",
                    result);
                    Console.WriteLine("Result::");
                    Console.WriteLine(result);
            }
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