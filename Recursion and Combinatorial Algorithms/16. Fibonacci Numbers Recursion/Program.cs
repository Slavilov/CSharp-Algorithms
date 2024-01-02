using System;

class Program
{
    static void Main()
    {
        Console.Write("Input number of terms for the Fibonacci series: ");
        int terms = Convert.ToInt32(Console.ReadLine());

        Console.Write("The Fibonacci series of " + terms + " terms is: ");
        for (int i = 0; i < terms; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
        Console.WriteLine();
    }
    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
