using System;
using System.Collections.Generic;

public class Graph
{
    private int _vertices; // Number of vertices
    private List<int>[] _adjacencyList; // Adjacency list

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

            Console.WriteLine("Depth First Traversal starting from vertex 0:");
            g.DFS();
        }
    }

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

    public void DFS()
    {
        bool[] visited = new bool[_vertices];
        for (int i = 0; i < _vertices; i++)
        {
            if (!visited[i])
            {
                DFSUtil(i, visited);
            }
        }
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int vertex in _adjacencyList[v])
        {
            if (!visited[vertex])
            {
                DFSUtil(vertex, visited);
            }
        }
    }
}
