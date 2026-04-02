using System;
using System.Collections.Generic;   
using System.Linq;

public class LoadBalancer
{
    private List<Server> servers = new List<Server>();  // List to hold registered servers
    private int lastUsedServer = -1; 
    
    public void RegisterServer(Server server)   // Method to register a new server to the load balancer
    {
        servers.Add(server);
    }

    public Server GetServerRoundRobin()   // Method to get a server using round-robin load balancing
    {
        lastUsedServer = (lastUsedServer + 1) % servers.Count;  // Move to the next server in a circular manner
        return servers[lastUsedServer];
    }

    public Server GetServerLeastConnections()   // Method to get a server with the least number of connections (requests)
    {
        return servers.OrderBy(s => s.RequestCount).First();
    }

    public Server GetServerIPHashing(string ipAddress)   // Method to get a server based on IP hashing
    {
        int index = Math.Abs(ipAddress.GetHashCode()) % servers.Count;
        return servers[index];
    }
}