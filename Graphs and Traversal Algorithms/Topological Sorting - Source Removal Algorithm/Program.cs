using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var graph = new Dictionary<char, List<char>>
        {
            { 'A', new List<char> { 'C' } },
            { 'B', new List<char> { 'C', 'D' } },
            { 'C', new List<char> { 'E' } },
            { 'D', new List<char> { 'F' } },
            { 'E', new List<char> { 'H', 'F' } },
            { 'F', new List<char> { 'G' } },
            { 'G', new List<char>() },
            { 'H', new List<char>() }
        };

        var sorted = TopologicalSort(graph);
        Console.WriteLine("Topological Sorting of the Graph:");
        Console.WriteLine(string.Join(" ", sorted));
    }

    static List<char> TopologicalSort(Dictionary<char, List<char>> graph)
    {
        var topologicalOrder = new List<char>();

        var inDegree = graph.ToDictionary(g => g.Key, g => 0);
        foreach (var adjacency in graph.Values)
        {
            foreach (var vertex in adjacency)
            {
                inDegree[vertex]++;
            }
        }

        // Collect nodes which have no incoming edges
        var sources = new Queue<char>(inDegree.Where(degree => degree.Value == 0).Select(degree => degree.Key));

        while (sources.Any())
        {
            var source = sources.Dequeue();
            topologicalOrder.Add(source);

            // For each node m with an edge e from source to m do
            foreach (var m in graph[source])
            {
                // Remove edge e from the graph
                inDegree[m]--;
                // If m has no other incoming edges then insert m into sources
                if (inDegree[m] == 0)
                {
                    sources.Enqueue(m);
                }
            }
        }

        // Check if there was a cycle in the graph
        if (topologicalOrder.Count != graph.Count)
        {
            throw new InvalidOperationException("The graph has at least one cycle and cannot be sorted topologically.");
        }

        return topologicalOrder;
    }
}
