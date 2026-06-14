var client = new ApiClient();

Console.WriteLine("Assessment Started");

// var discovery = new Discovery(client);

// await discovery.Run();

var fetchData = new FetchData(client);

await fetchData.Run();

//var submission = new Submission(client);

//await submission.Run();
