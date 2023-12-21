using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of nested loops: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        SimulateLoops(arr, 0, n);
    }

    static void SimulateLoops(int[] arr, int depth, int n)
    {
        if (depth == n)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            arr[depth] = i;
            SimulateLoops(arr, depth + 1, n);
        }
    }
}
