using System;
using System.Linq;

class HamiltonianAlgoritmByAndrey
{
    public static void HamiltonianAlgoritm(int[,] Matrix)
    {
        int n = Matrix.GetLength(0);
        List<int> path = new List<int>();
        List<List<int>> hamiltonianCycles = new List<List<int>>();
        List<List<int>> hamiltonianPaths = new List<List<int>>();

        bool[] visited = new bool[n];

        //начинаем с V1
        path.Add(0);
        visited[0] = true;
        FindPaths(Matrix, visited, path, hamiltonianCycles, hamiltonianPaths, 0);

        if (hamiltonianCycles.Count == 0)
        {
            Console.WriteLine("В графе нет гамильтоновых циклов.");
        }
        else
        {
            Console.WriteLine("Гамильтоновы циклы:");
            foreach (var cycle in hamiltonianCycles)
            {
                Console.WriteLine(string.Join(" -> ", cycle) + " -> " + cycle[0]);
            }
        }

        if (hamiltonianPaths.Count == 0)
        {
            Console.WriteLine("В графе нет гамильтоновых путей.");
        }
        else
        {
            Console.WriteLine("Гамильтоновы пути:");
            foreach (var p in hamiltonianPaths)
            {
                Console.WriteLine(string.Join(" -> ", p));
            }
        }
    }

    private static void FindPaths(int[,] Matrix, bool[] visited, List<int> path, List<List<int>> hamiltonianCycles, List<List<int>> hamiltonianPaths, int currentVertex)
    {
        int n = Matrix.GetLength(0);

        if (path.Count == n)
        {
            if (Matrix[currentVertex, path[0]] == 1)
            {
                hamiltonianCycles.Add(new List<int>(path));
            }
            else
            {
                hamiltonianPaths.Add(new List<int>(path));
            }
            return;
        }

        for (int nextVertex = 0; nextVertex < n; nextVertex++)
        {
            if (Matrix[currentVertex, nextVertex] == 1 && !visited[nextVertex])
            {
                visited[nextVertex] = true;
                path.Add(nextVertex);

                FindPaths(Matrix, visited, path, hamiltonianCycles, hamiltonianPaths, nextVertex);

                visited[nextVertex] = false;
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    public static void Main()
    {
        int[,] Matrix = {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 1, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 0, 1, 1, 0, 1 },
            { 0, 0, 1, 1, 0 }
        };

        HamiltonianAlgoritm(Matrix);
    }
}
