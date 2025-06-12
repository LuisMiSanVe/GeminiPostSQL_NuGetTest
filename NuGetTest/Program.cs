using GeminiPostSQL;
using Newtonsoft.Json;

// Initialize client with the apiKey and separate database data Builder
GeminiPostSQLClient client = new GeminiPostSQLClient("API_KEY", "DB_IP", "DB_USER", "DB_PASS", "DB_NAME");

// Optional parameters
// client.mapOnGenerateSQL = true; // Map Database automatically in GenerateSQL() method
// client.runOnGenerateSQL = true; // Run query automatically in GenerateSQL() method

Console.WriteLine("Mapping database...");
if (client.MapDatabase().Result) 
{
    Console.WriteLine("Mapping complete.");

    Console.WriteLine("Gemini is generating the SQL sentence...");
    string query = client.GenerateSQL("Last albaran of 2025").Result;
    Console.WriteLine("Generated query: " + query);

    Console.WriteLine("Running query...");
    string result = JsonConvert.SerializeObject(client.RunQuery(query).Result);

    Console.WriteLine("Result table:\n" + result);
}
else
{
    Console.WriteLine("The mapping process failed.");
}