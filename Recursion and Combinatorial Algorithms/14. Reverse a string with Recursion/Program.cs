using System;

class Program
{
    static void Main()
    {
        Console.Write("Input the string: ");
        string inputString = Console.ReadLine();

        string reversedString = ReverseString(inputString);

        Console.WriteLine("The reverse of the string is: " + reversedString);
    }

    // Function to reverse a string using recursion
    static string ReverseString(string str)
    {
        if (str.Length <= 1)
            return str;
        else
            return str[str.Length - 1] + ReverseString(str.Substring(0, str.Length - 1));
    }
}
