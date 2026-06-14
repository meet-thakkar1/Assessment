var client = new ApiClient();

Console.WriteLine("Assessment Started");

var discovery = new Discovery(client);

await discovery.Run();
