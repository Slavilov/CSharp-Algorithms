using System;

class Program
{
    static void Main()
    {
        Console.Write("Input a string: ");
        string inputString = Console.ReadLine();

        if (IsPalindrome(inputString, 0, inputString.Length - 1))
            Console.WriteLine("The string is Palindrome.");
        else
            Console.WriteLine("The string is not Palindrome.");
    }
    static bool IsPalindrome(string str, int start, int end)
    {
        if (start >= end)
            return true;
        if (str[start] != str[end])
            return false;
        return IsPalindrome(str, start + 1, end - 1);
    }
}
