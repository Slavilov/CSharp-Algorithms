using System;
using System.Collections.Generic;
using System.Linq;

public class ConnectedArea : IComparable<ConnectedArea>
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Size { get; set; }

    public int CompareTo(ConnectedArea other)
    {
        // Sort by size descending, row ascending, column ascending
        int result = other.Size.CompareTo(this.Size);
        if (result == 0)
        {
            result = this.Row.CompareTo(other.Row);
        }

        if (result == 0)
        {
            result = this.Col.CompareTo(other.Col);
        }

        return result;
    }
}

public class ConnectedAreasInMatrix
{
    private static char[,] matrix;
    private static bool[,] visited;
    private static List<ConnectedArea> connectedAreas;

    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        matrix = new char[rows, cols];
        visited = new bool[rows, cols];
        connectedAreas = new List<ConnectedArea>();

        for (int row = 0; row < rows; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        FindConnectedAreas();

        // Sort the connected areas
        connectedAreas.Sort();

        Console.WriteLine($"Total areas found: {connectedAreas.Count}");
        for (int i = 0; i < connectedAreas.Count; i++)
        {
            Console.WriteLine($"Area #{i + 1} at ({connectedAreas[i].Row}, {connectedAreas[i].Col}), size: {connectedAreas[i].Size}");
        }
    }

    private static void FindConnectedAreas()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == '-' && !visited[row, col])
                {
                    ConnectedArea area = new ConnectedArea { Row = row, Col = col };
                    area.Size = ExploreArea(row, col);
                    connectedAreas.Add(area);
                }
            }
        }
    }

    private static int ExploreArea(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
        {
            return 0;
        }

        if (visited[row, col] || matrix[row, col] != '-')
        {
            return 0;
        }

        visited[row, col] = true;

        return 1 + ExploreArea(row - 1, col) + ExploreArea(row + 1, col) +
                   ExploreArea(row, col - 1) + ExploreArea(row, col + 1);
    }
}
