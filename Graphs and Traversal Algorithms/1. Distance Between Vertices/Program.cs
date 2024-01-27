using System;
using System.Collections.Generic;

class Program
{

    private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
    static void Main()
    {

        int numberOfNodes = int.Parse(Console.ReadLine());
        int numberOfPairsToFindPath = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfNodes; i++)
        {
            Console.WriteLine("Enter a node and its directed nodes (format 'X:Y Z')");
            string input = Console.ReadLine();

            var parts = input.Split(':');
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid input format.");
                continue;
            }

            int node;
            if (!int.TryParse(parts[0], out node))
            {
                Console.WriteLine("Invalid node number.");
                continue;
            }

            if (!graph.ContainsKey(node))
            {
                graph[node] = new List<int>();
            }

            var directedNodes = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var str in directedNodes)
            {
                int directedNode;
                if (int.TryParse(str, out directedNode))
                {
                    graph[node].Add(directedNode);
                }
            }
        }

        for (int i = 0; i < numberOfPairsToFindPath; i++)
        {
            var pair = Console.ReadLine()
                .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int startNode = int.Parse(pair[0]);
            int endNode = int.Parse(pair[1]);

            int distance = BFS(graph, startNode, endNode);
            Console.WriteLine($" ({startNode}, {endNode}) -> {distance}");

        }

        //// Display the graph
        //Console.WriteLine("Directed Graph:");
        //foreach (var kvp in graph)
        //{
        //    Console.Write($"{kvp.Key}: ");
        //    foreach (var directedNode in kvp.Value)
        //    {
        //        Console.Write($"{directedNode} ");
        //    }
        //    Console.WriteLine();
        //}
    }
    static int BFS(Dictionary<int, List<int>> graph, int startNode, int endNode)
    {
        if (startNode == endNode)
        {
            return 0;
        }

        Queue<int> queue = new Queue<int>();
        Dictionary<int, int> distance = new Dictionary<int, int>();
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue(startNode);
        visited.Add(startNode);
        distance[startNode] = 0;

        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();

            foreach (int neighbor in graph[currentNode])
            {
                if (!visited.Contains(neighbor))
                {
                    distance[neighbor] = distance[currentNode] + 1;

                    if (neighbor == endNode)
                    {
                        return distance[neighbor];
                    }

                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }

        return -1; // Return -1 if endNode is not reachable
    }
}
