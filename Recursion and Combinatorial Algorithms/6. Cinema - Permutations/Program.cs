using System;

namespace Cinema

{
    class Program

    {
        static void Main(string[] args)

        {
            List<string> namesOfFriends = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> friendsPlaces = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "generate")
            {
                string[] tokens = input.Split(" - ");
                if (tokens.Length == 2)
                {
                    string name = tokens[0];
                    if (int.TryParse(tokens[1], out int place))
                    {
                        friendsPlaces[name] = place;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format. Please use '{name} - {place}' format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input format. Please use '{name} - {place}' format.");
                }
            }

            GetPermutations(namesOfFriends, friendsPlaces, 0, namesOfFriends.Count - 1);

        }
        static void GetPermutations(List<string> namesOfFriends, Dictionary<string,int> friendsPlaces,  int k, int m)
        {
            bool flag = true;
            if (k == m)
            {
                foreach (var pair in friendsPlaces)
                {
                    string name = pair.Key;
                    int desiredPosition = (pair.Value)-1;
                    if (namesOfFriends[desiredPosition] != name)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    Console.WriteLine(string.Join(", ", namesOfFriends));
                }
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(namesOfFriends, k, i);
                    GetPermutations(namesOfFriends, friendsPlaces, k + 1, m);
                    Swap(namesOfFriends, k, i); //backtrack
                }
            }
        }

        static void Swap<T>(List<T> list, int a, int b)
        {
            T tmp = list[a];
            list[a] = list[b];
            list[b] = tmp;
        }
    }
}