using System;

namespace reverseArray

{
    class Program

    {
        static void Main(string[] args)

        {
            string[] arrayToBeReversed;
            Console.WriteLine("Now type in the size of the Array!");
            int n = int.Parse(Console.ReadLine());
            arrayToBeReversed = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Now type in each element of the array!");
                arrayToBeReversed[i] = Console.ReadLine();
            }
            ReverseArray(arrayToBeReversed, 0);

        }
        static void ReverseArray(string[] arrayToBeReversed, int indx)
        {
            if (indx >= arrayToBeReversed.Length/2)
            {
                Console.WriteLine(string.Join(", ", arrayToBeReversed));
                return;
            }

            string tempElement = arrayToBeReversed[indx];
            arrayToBeReversed[indx] = arrayToBeReversed[arrayToBeReversed.Length - (indx + 1)];
            arrayToBeReversed[arrayToBeReversed.Length - (indx + 1)] = tempElement;

            ReverseArray(arrayToBeReversed, indx+1);
        }
    }
}