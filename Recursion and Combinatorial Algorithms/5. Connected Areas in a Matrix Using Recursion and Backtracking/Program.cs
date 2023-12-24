using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static char[,] matrix;
    private static bool[,] visited;
    private static List<(int, int, int)> areas;

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        matrix = new char[rows, cols];
        visited = new bool[rows, cols];
        areas = new List<(int, int, int)>();

        for (int row = 0; row < rows; row++)
        {
            var line = Console.ReadLine();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        FindConnectedAreas();

        var sortedAreas = areas.OrderByDescending(a => a.Item3).ThenBy(a => a.Item1).ThenBy(a => a.Item2).ToList();

        Console.WriteLine($"Total areas found: {sortedAreas.Count}");
        for (int i = 0; i < sortedAreas.Count; i++)
        {
            Console.WriteLine($"Area #{i + 1} at ({sortedAreas[i].Item1}, {sortedAreas[i].Item2}), size: {sortedAreas[i].Item3}");
        }
    }

    static void FindConnectedAreas()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == '-' && !visited[row, col])
                {
                    int size = ExploreArea(row, col);
                    areas.Add((row, col, size));
                }
            }
        }
    }

    static int ExploreArea(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            return 0;

        if (visited[row, col] || matrix[row, col] != '-')
            return 0;

        visited[row, col] = true;

        return 1 + ExploreArea(row - 1, col)   // up
                 + ExploreArea(row + 1, col)   // down
                 + ExploreArea(row, col - 1)   // left
                 + ExploreArea(row, col + 1);  // right
    }
}
