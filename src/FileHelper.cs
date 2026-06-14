public static class FileHelper
{
    public static async Task SaveAsync(
        string path,
        string content)
    {
        var dir = Path.GetDirectoryName(path);

        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);

        await File.WriteAllTextAsync(path, content);
    }
}