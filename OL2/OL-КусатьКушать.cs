using System;
using System.IO;
using System.Linq;

class Est_Kysat
{
    static int[][] FillMatrix(string[] data, int countPicks)
    {
        int[][] matrix = new int[countPicks][];
        for (int i = 0; i < countPicks; i++)
        {
            matrix[i] = new int[countPicks];
        }
        for (int i = 1; i < countPicks; i++)
        {
            var parts = data[i].Split();
            int peak = int.Parse(parts[0]);
            int value = int.Parse(parts[1]);
            matrix[i][peak] = value;
            matrix[peak][i] = value;
            for (int j = 0; j < i; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][j] = value + matrix[peak][j];
                    matrix[j][i] = value + matrix[peak][j];
                }
            }
        }
        return matrix;
    }

    static List<int> FillBerries(string[] data, int minSpel)
    {
        List<int> berries = new List<int>();
        foreach (var line in data)
        {
            var parts = line.Split();
            int berryValue = int.Parse(parts[0]);
            int spel = int.Parse(parts[1]);
            if (spel >= minSpel)
            {
                berries.Add(berryValue);
            }
        }
        return berries;
    }

    static (int, int) FindMinWay(int[][] matrix, int location, List<int> way)
    {
        int minValue = int.MaxValue;
        int nextLocation = -1;
        foreach (var w in way)
        {
            if (matrix[location][w] < minValue)
            {
                minValue = matrix[location][w];
                nextLocation = w;
            }
        }
        return (minValue, nextLocation);
    }

    static int GiveAnswer(int[][] matrix, int location, List<int> berries)
    {
        int totalSum = 0;
        while (berries.Count > 0)
        {
            var (minWay, newLocation) = FindMinWay(matrix, location, berries);
            totalSum += minWay;
            location = newLocation;
            berries.Remove(location);
        }
        return totalSum;
    }

    static void Main()
    {
            string[] data = File.ReadAllLines($"input_s1_18.txt");
            var firstLine = data[0].Split();
            int countPeaks = int.Parse(firstLine[0]) + 1;
            int countBerries = int.Parse(firstLine[1]);
            int[][] matrix = FillMatrix(data, countPeaks);
            var lastLine = data[data.Length - 1].Split().Select(int.Parse).ToArray();
            int location = lastLine[0];
            int minSpel = lastLine[1];
            string[] dataCopy = data.Skip(countPeaks).Take(countBerries).ToArray();
            List<int> berries = FillBerries(dataCopy, minSpel);
            int myAnswer = GiveAnswer(matrix, location, berries);
            Console.WriteLine(myAnswer);
        
    }
}
