using GeminiPostSQL;
using Newtonsoft.Json;

// Initialize client with the apiKey and separate database data Builder
GeminiPostSQLClient client = new GeminiPostSQLClient("AIzaSyAbeCmpBK9C5JvxqNcOb2LRaWkyltCQ7fI", "192.168.1.14", "postgres", "WJXSBJg.", "betaconsultores");

// Optional parameters
client.mapOnGenerateSQL = true; // Map Database automatically in GenerateSQL() method
client.runOnGenerateSQL = true; // Run query automatically in GenerateSQL() method

Console.WriteLine("Mapping database...");

if (!client.mapOnGenerateSQL)
    client.MapDatabase();

Console.WriteLine("Mapping complete.");

Console.WriteLine("Gemini is generating the SQL sentence...");
string query = client.GenerateSQL("Last albaran of 2025").Result;

if (!client.runOnGenerateSQL)
{
    Console.WriteLine("Generated query: " + query);
    Console.WriteLine("Running query...");
    query = JsonConvert.SerializeObject(client.RunQuery(query).Result);

    Console.WriteLine("Result table:\n" + query);
}
else
    Console.WriteLine("Result table:\n" + query);