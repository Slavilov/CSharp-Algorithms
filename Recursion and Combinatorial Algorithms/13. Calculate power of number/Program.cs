using System;

class Program
{
    static void Main()
    {
        Console.Write("Input the base value: ");
        int baseValue = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input the exponent: ");
        int exponent = Convert.ToInt32(Console.ReadLine());

        int result = Power(baseValue, exponent);

        Console.WriteLine($"The value of {0} to the power of {1} is: {2}", baseValue, exponent, result);
    }

    static int Power(int baseValue, int exponent)
    {
        if (exponent == 0)
            return 1;
        else
            return baseValue * Power(baseValue, exponent - 1);
    }
}
