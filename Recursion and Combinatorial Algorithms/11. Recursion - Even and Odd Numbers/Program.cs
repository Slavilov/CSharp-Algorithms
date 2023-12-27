using System;

namespace addNumbersBackwards

{
    class Program

    {

        private static List<int> evenNumbers = new List<int>();
        private static List<int> oddNumbers = new List<int>();
        private static int startNumber = int.Parse(Console.ReadLine());
        private static int endNumber = int.Parse(Console.ReadLine());
        static void Main(string[] args)

        {
            List<int> numbers = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            GetSum(numbers, 0);
        }
        public static void GetSum(List<int> numbers, int index)
        {
            if (index == numbers.Count-1)
            {
                Console.WriteLine($"All even numbers from {startNumber} to {endNumber} are:");
                Console.WriteLine(string.Join(", ", evenNumbers));

                Console.WriteLine($"All odd numbers from {startNumber} to {endNumber} are:");
                Console.WriteLine(string.Join(", ", oddNumbers));
                return;
            }
            if (numbers[index]%2 == 0)
            {
                evenNumbers.Add(numbers[index]);
            }
            else
            {
                oddNumbers.Add(numbers[index]);
            }
            GetSum(numbers, index+1);
        }
    }
}