using System;
using System.IO;

class ZolotoMy
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input_s1_10.txt");
        int N = int.Parse(lines[0]);
        List<string> words = new List<string>();
        Dictionary<char, int> startLimitations = new Dictionary<char, int>();
        Dictionary<char, int> endLimitations = new Dictionary<char, int>();

        for (int i = 1; i <= N; i++)
        {
            words.Add(lines[i]);
        }

        int F = int.Parse(lines[N + 1]);
        int index = N + 2;
        for (int i = 0; i < F; i++)
        {
            string[] parts = lines[index++].Split(' ');
            startLimitations[parts[0][0]] = int.Parse(parts[1]);
        }

        int L = int.Parse(lines[index++]);
        for (int i = 0; i < L; i++)
        {
            string[] parts = lines[index++].Split(' ');
            endLimitations[parts[0][0]] = int.Parse(parts[1]);
        }

        int count = 0;
        foreach (string word in words)
        {
            char firstChar = word[0];
            char lastChar = word[word.Length - 1];
            if (startLimitations.ContainsKey(firstChar) && endLimitations.ContainsKey(lastChar))
            {
                if (startLimitations[firstChar] > 0 && endLimitations[lastChar] > 0)
                {
                    startLimitations[firstChar]--;
                    endLimitations[lastChar]--;
                    count++;
                }
            }
        }


        Console.WriteLine(count);
    }
}
