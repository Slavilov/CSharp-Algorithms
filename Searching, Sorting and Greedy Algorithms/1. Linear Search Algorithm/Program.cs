using System;

class Program
{
    static void Main()
    {
        int[] data = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine("Please type in what number you want to search for in the array:");
        int x = int.Parse(Console.ReadLine());

        int result = LinearSearch(data, x);
        if (result == -1)
            Console.WriteLine("Element not found");
        else
            Console.WriteLine("Element found at index: " + result);
    }
    static int LinearSearch(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
                return i;
        }
        return -1;
    }
}
