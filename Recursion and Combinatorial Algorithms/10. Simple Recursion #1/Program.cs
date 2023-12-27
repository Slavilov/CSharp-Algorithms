using System;

namespace addNumbersBackwards

{
    class Program

    {
        static void Main(string[] args)

        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSum(n));
        }
        public static int GetSum(int n)
        {
            if (n ==1)
            {
                return 1;
            }
            return n+ GetSum(n - 1);
        }
    }
}