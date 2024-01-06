using System;

class Program
{
    // Main Method
    static void Main()
    {
        int[] data = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine("Please type in what number you want to search for in the array:");
        int x = int.Parse(Console.ReadLine());

        int result = BinarySearch(data, 0, data.Length - 1, x);
        if (result == -1)
            Console.WriteLine("Element not found");
        else
            Console.WriteLine("Element found at index: " + result);
    }
    static int BinarySearch(int[] arr, int l, int r, int x)
    {
        if (r >= l)
        {
            int mid = l + (r - l) / 2;

            // If the element is present at the middle
            if (arr[mid] == x)
                return mid;

            // If element is smaller than mid, then it can only be present in left subarray
            if (arr[mid] > x)
                return BinarySearch(arr, l, mid - 1, x);

            // Else the element can only be present in right subarray
            return BinarySearch(arr, mid + 1, r, x);
        }

        return -1; // Element not found
    }
}
