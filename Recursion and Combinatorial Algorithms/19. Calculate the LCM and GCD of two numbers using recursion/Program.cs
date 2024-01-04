using System;

class Program
{
    static void Main()
    {
        Console.Write("Input the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int gcd = GCD(num1, num2);
        int lcm = LCM(num1, num2);

        Console.WriteLine($"The GCD of {num1} and {num2} = {gcd}");
        Console.WriteLine($"The LCM of {num1} and {num2} = {lcm}");
    }
    static int GCD(int a, int b)
    {
        if (b == 0)
            return a;
        else
            return GCD(b, a % b);
    }

    static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }
}
