using System;

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original Array: " + String.Join(", ", array));

        ReverseArray(array, 0, array.Length - 1);
        Console.WriteLine("Reversed Array: " + String.Join(", ", array));
    }

    static void ReverseArray(int[] arr, int start, int end)
    {
        if (start >= end)
            return;

        int temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;

        ReverseArray(arr, start + 1, end - 1);
    }
}
