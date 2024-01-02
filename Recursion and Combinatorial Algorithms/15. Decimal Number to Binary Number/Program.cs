using System;

class Program
{

    static void Main()
    {
        Console.Write("Input a decimal number: ");
        int decimalNumber = Convert.ToInt32(Console.ReadLine());

        string binaryNumber = DecimalToBinary(decimalNumber);

        Console.WriteLine("The binary equivalent of " + decimalNumber + " is: " + binaryNumber);
    }

    static string DecimalToBinary(int number)
    {
        if (number == 0)
            return "";
        else
            return DecimalToBinary(number / 2) + (number % 2).ToString();
    }
}
