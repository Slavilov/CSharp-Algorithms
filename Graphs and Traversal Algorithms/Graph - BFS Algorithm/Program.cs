using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine("Breadth First Traversal starting from vertex 2:");
        g.BFS(2);
    }
}

public class Graph
{
    private int _vertices; // Number of vertices
    private List<int>[] _adjacencyList; // Adjacency list

    public Graph(int vertices)
    {
        _vertices = vertices;
        _adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            _adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        _adjacencyList[v].Add(w); // Add w to v's list.
    }

    public void BFS(int startVertex)
    {
        bool[] visited = new bool[_vertices];
        Queue<int> queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count != 0)
        {
            int v = queue.Dequeue();
            Console.Write(v + " ");

            foreach (int adj in _adjacencyList[v])
            {
                if (!visited[adj])
                {
                    visited[adj] = true;
                    queue.Enqueue(adj);
                }
            }
        }
    }
}
