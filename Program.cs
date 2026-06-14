var client = new ApiClient();

Console.WriteLine("Assessment Started");

// var discovery = new Discovery(client);

// await discovery.Run();

 //var fetchData = new FetchData(client);

 //await fetchData.Run();

var submission = new Submission(client);

await submission.Submit("content_hash","6335aaa16b92684ae24161e0633dff8bc5b784cbd51e92f36a180b264bb2d4a1","all notes are in notes folder layer1 file");


 var generateHash = new GenerateHash();

 await generateHash.Run();
