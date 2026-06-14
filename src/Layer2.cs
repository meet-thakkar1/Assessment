using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
public class Layer2
{
    public async Task Run()
    {

        var allRecords = new List<string>();

for (int page = 1; page <= 5; page++)
{
    var json =
        await File.ReadAllTextAsync(
            $"data/raw/page{page}.json");

var response =
        JsonSerializer.Deserialize<DatasetResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

    if (response != null)
    {
        allRecords.AddRange(response.Data);
    }
}


        var bytes = Convert.FromBase64String(allRecords[0]);

Console.WriteLine($"Length = {bytes.Length}");

Console.WriteLine(
    Convert.ToHexString(bytes.Take(64).ToArray()));

    var lengths = allRecords
    .Select(x => Convert.FromBase64String(x).Length)
    .Distinct()
    .OrderBy(x => x);

foreach (var len in lengths)
{
    Console.WriteLine(len);
}
    }
}