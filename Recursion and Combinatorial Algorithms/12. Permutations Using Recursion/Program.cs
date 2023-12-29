using System;

class Program
{
    static void Main()
    {
        Console.Write("Input the number of elements to store in the array [maximum 5 digits ]: ");
        int n = Int32.Parse(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine($"Input {n} number of elements in the array :");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"element - {i} : ");
            arr[i] = Int32.Parse(Console.ReadLine());
        }

        Console.WriteLine("The Permutations with a combination of " + n + " digits are :");
        Permute(arr, 0, n - 1);
        Console.WriteLine();
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Permute(int[] arr, int start, int end)
    {
        if (start == end)
        {
            Console.Write(String.Join("", arr) + " ");
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                Swap(ref arr[start], ref arr[i]);
                Permute(arr, start + 1, end);
                Swap(ref arr[start], ref arr[i]); // backtrack
            }
        }
    }
}
