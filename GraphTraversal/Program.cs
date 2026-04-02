using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList;   // Stores the graph as an adjacency list
    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();   // Initialize the adjacency list
    }
    // Adds an undirected edge between source and destination
    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<int>();
        }
        adjacencyList[source].Add(destination);
        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new List<int>();
        }
        adjacencyList[destination].Add(source);
    }
    
    // Performs Depth-First Search starting from the given node
    public void DFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();  // Track of visited nodes
        DFSRecursive(start, visited);   // Call the recursive helper
    }
    // Recursive helper method for DFS
    private void DFSRecursive(int node, HashSet<int> visited)
    {
        if (visited.Contains(node))     //skip if the node has already been visited
            return;
        Console.Write(node + " ");
        visited.Add(node);              // Mark the node as visited
        if (adjacencyList.ContainsKey(node))    // Explore neighbors
        {
            foreach (var neighbor in adjacencyList[node])
            {
                DFSRecursive(neighbor, visited);    // Recursive call for each unvisited neighbor
            }
        }
    }

    // Performs Breadth-First Search starting from the given node
    public void BFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();  // Track of visited nodes
        Queue<int> queue = new Queue<int>();        // Queue for BFS
        queue.Enqueue(start);                       // Mark the starting node as visited
        visited.Add(start);                         //Enqueue the starting node
        while (queue.Count > 0)                     // Continue until the queue is empty
        {
            int node = queue.Dequeue();     // Dequeue next node
            Console.Write(node + " ");      // Process current node
            if (adjacencyList.ContainsKey(node))        //traverse neighbors
            {
                foreach (var neighbor in adjacencyList[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();      // graph instance

        //sample edges
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 6);

        
        Console.WriteLine("Depth-First Traversal starting from node 1:");
        graph.DFS(1);

        Console.WriteLine("\nBreadth-First Traversal starting from node 1:");
        graph.BFS(1);
    }
}