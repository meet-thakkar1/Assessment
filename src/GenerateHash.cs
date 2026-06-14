using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class GenerateHash
{
    public async Task Run()
    {

var allRecords = new List<string>();

for (int page = 1; page <= 5; page++)
{
    var json =
        await File.ReadAllTextAsync(
            $"data/raw/page{page}.json");

//var hash = SHA256.HashData(Encoding.UTF8.GetBytes(json));

//Console.WriteLine(Convert.ToHexString(hash).ToLower());



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


    using var sha = SHA256.Create();

foreach (var record in allRecords)
{
    var bytes = Convert.FromBase64String(record);

    sha.TransformBlock(bytes, 0, bytes.Length, null, 0);
}

sha.TransformFinalBlock(Array.Empty<byte>(), 0, 0);

 var hash = Convert.ToHexString(sha.Hash!).ToLower();
Console.WriteLine(hash);
}
}
