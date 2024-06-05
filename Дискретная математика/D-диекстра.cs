using System;
using System.Collections.Generic;

class Dijkstra
{
    public static void DijkstraAlgorithm(List<List<int>> graph, int source)
    {
        int verticesCount = graph.Count;
        List<int> distances = new List<int>(new int[verticesCount]);
        List<bool> shortestPathTreeSet = new List<bool>(new bool[verticesCount]);

        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
        }

        distances[source] = 0;

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinimumDistance(distances, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (!shortestPathTreeSet[v] && graph[u][v] != 0 && distances[u] != int.MaxValue && distances[u] + graph[u][v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u][v];
                }
            }
        }

        Print(distances, verticesCount);
    }

    private static int MinimumDistance(List<int> distances, List<bool> shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < verticesCount; v++)
        {
            if (!shortestPathTreeSet[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static void Print(List<int> distances, int verticesCount)
    {
        Console.WriteLine("Расстояние от вершины до источника");
        for (int i = 0; i < verticesCount; i++)
            Console.WriteLine(i + " \t\t " + distances[i]);
    }

    static void Main()
    {
        List<List<int>> graph = new List<List<int>>
        {
            new List<int> { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            new List<int> { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            new List<int> { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            new List<int> { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            new List<int> { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            new List<int> { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            new List<int> { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            new List<int> { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
        };

        Console.Write("Укажитье вершину от 0 до 8: ");
        int sourse = int.Parse(Console.ReadLine());

        DijkstraAlgorithm(graph, sourse);
    }
}