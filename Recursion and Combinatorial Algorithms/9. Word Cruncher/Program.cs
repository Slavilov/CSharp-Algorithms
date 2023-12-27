using System;
using System.Collections.Generic;
using System.Linq;

public class WordCruncher
{
    private static List<string> inputWords;
    private static string target;
    private static LinkedList<string> selectedWords;
    private static Dictionary<int, List<string>> wordsByIndex;
    private static HashSet<string> result;

    public static void Main()
    {
        inputWords = Console.ReadLine().Split(", ").ToList();
        target = Console.ReadLine();

        selectedWords = new LinkedList<string>();
        wordsByIndex = new Dictionary<int, List<string>>();
        result = new HashSet<string>();

        foreach (var word in inputWords)
        {
            int index = target.IndexOf(word);
            while (index != -1)
            {
                if (!wordsByIndex.ContainsKey(index))
                {
                    wordsByIndex[index] = new List<string>();
                }

                wordsByIndex[index].Add(word);
                index = target.IndexOf(word, index + 1);
            }
        }

        Generate(0);
        Console.WriteLine(string.Join(Environment.NewLine, result));
    }

    private static void Generate(int index)
    {
        if (index >= target.Length)
        {
            result.Add(string.Join(" ", selectedWords));
            return;
        }

        if (!wordsByIndex.ContainsKey(index)) return;

        foreach (var word in wordsByIndex[index])
        {
            selectedWords.AddLast(word);
            Generate(index + word.Length);
            selectedWords.RemoveLast();
        }
    }
}
