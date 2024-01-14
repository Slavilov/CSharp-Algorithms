using System;
class Program
{
    static void Main()
    {
        double[] coins = { 0.25, 0.10, 0.05, 0.01 };

        Console.Write("Enter the amount in dollars (e.g., 1.36): ");
        double amount = double.Parse(Console.ReadLine());

        MinCoins(coins, amount);
    }

    public static void MinCoins(double[] coins, double amount)
    {
        int[] count = new int[coins.Length];
        double remainingAmount = amount;

        for (int i = 0; i < coins.Length; i++)
        {
            // Calculate the count of each coin in the change
            count[i] = (int)(remainingAmount / coins[i]);
            remainingAmount -= count[i] * coins[i];

            remainingAmount = Math.Round(remainingAmount, 2);
        }

        Console.WriteLine($"The minimum number of coins for {amount} dollars:");
        for (int i = 0; i < coins.Length; i++)
        {
            if (count[i] != 0)
            {
                Console.WriteLine($"{coins[i]}$: {count[i]}");
            }
        }
    }
}
