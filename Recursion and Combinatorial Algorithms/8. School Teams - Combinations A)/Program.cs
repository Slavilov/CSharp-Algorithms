using System;
using System.Collections.Generic;

class SchoolTeams
{
    static void Main()
    {
        string[] girls = Console.ReadLine().Split(", ");
        string[] boys = Console.ReadLine().Split(", ");

        GenerateTeams(girls, boys, new List<string>(), 0, 0);
    }

    static void GenerateTeams(string[] girls, string[] boys, List<string> currentTeam, int girlIndex, int boyIndex)
    {
        if (currentTeam.Count == 5)
        {
            if (currentTeam.FindAll(x => Array.IndexOf(girls, x) != -1).Count == 3)
            {
                Console.WriteLine(string.Join(", ", currentTeam));
            }
            return;
        }

        for (int i = girlIndex; i < girls.Length; i++)
        {
            currentTeam.Add(girls[i]);
            GenerateTeams(girls, boys, currentTeam, i + 1, boyIndex);
            currentTeam.RemoveAt(currentTeam.Count - 1);
        }

        for (int i = boyIndex; i < boys.Length; i++)
        {
            currentTeam.Add(boys[i]);
            GenerateTeams(girls, boys, currentTeam, girlIndex, i + 1);
            currentTeam.RemoveAt(currentTeam.Count - 1);
        }
    }
}
