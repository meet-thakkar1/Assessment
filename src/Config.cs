using DotNetEnv;

public static class Config
{
    static Config()
    {
        Env.Load();
    }

    public static string BaseUrl =>
        Environment.GetEnvironmentVariable("BASE_URL")!;

    public static string ApiKey =>
        Environment.GetEnvironmentVariable("API_KEY")!;
}