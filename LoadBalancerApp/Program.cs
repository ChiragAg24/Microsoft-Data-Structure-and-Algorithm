using System;
using System.Collections.Generic;

public class Server
{
    public string Id{get; }      // Unique identifier for the server
    public int RequestCount{get; private set;}  // Number of requests handled by this server
    public Server(string id)    // Constructor to initialize the server with an ID and set request count to 0
    {
        Id = id;
        RequestCount = 0;
    }
    public void HandleRequest()   // Method to simulate handling a request, increments the request count
    {
        RequestCount++;
    }
}

class Program
{
    static void Main()
    {
        LoadBalancer lb = new LoadBalancer();

        lb.RegisterServer(new Server("Server1"));
        lb.RegisterServer(new Server("Server2"));
        lb.RegisterServer(new Server("Server3"));

        List<string> clientIPs = new List<string> { "192.168.1.1", "192.168.1.2", "192.168.1.3","192.168.1.4" };

        Console.WriteLine("Round Robin Load Balancing:");
        foreach (var ip in clientIPs)
        {
            var server = lb.GetServerRoundRobin();
            server.HandleRequest();
            Console.WriteLine($"Request from {ip} handled by {server.Id}");
        }
        Console.WriteLine("\nLeast Connections Distribution:");
        foreach (var ip in clientIPs)
        {
            var server = lb.GetServerLeastConnections();
            server.HandleRequest();
            Console.WriteLine($"Request from {ip} handled by {server.Id}");
        }
        Console.WriteLine("\nIP Hashing Distribution:");
        foreach (var ip in clientIPs)
        {
            var server = lb.GetServerIPHashing(ip);
            server.HandleRequest();
            Console.WriteLine($"Request from {ip} handled by {server.Id}");
        }
    }
}