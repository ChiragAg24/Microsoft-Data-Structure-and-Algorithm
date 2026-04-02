using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

class Program
{
    static async Task Main()    // Entry point of the application
    {
        Console.WriteLine("Starting API Request...");
        string result = await FetchDataAsync();     // Await the asynchronous method to fetch data
        Console.WriteLine($"Fetched data: {result}");
        
        await HandleMultipleRequestsAsync(); // Await the method that handles multiple API requests
    }
    
    // Asynchronous method to simulate fetching data
    static async Task<string> FetchDataAsync(string requestName)    
    {
        await Task.Delay(2000); // Simulate a delay for fetching data
        return "API request completed successfully!"; // Return a result after the delay
    }

    // Asynchronous method to handle multiple API requests concurrently
    static async Task HandleMultipleRequestsAsync()
    {
        Task<string> request1 = FetchDataAsync("Request 1");
        Task<string> request2 = FetchDataAsync("Request 2");
        Task<string> request3 = FetchDataAsync("Request 3");

        string[] results = await Task.WhenAll(request1, request2, request3); // Await all requests to complete

        foreach (string result in results)
        {
            Console.WriteLine(result); // Print each result from the completed requests
        }
    }
}