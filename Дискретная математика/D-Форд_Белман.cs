using System;
using System.Collections.Generic;

class FordBellman
{
    public static void Main()
    {
        int vertices = 5;
        int edges = 8;
        int[,] edgeList = {
            {0, 1, -1},
            {0, 2, 4},
            {1, 2, 3},
            {1, 3, 2},
            {1, 4, 2},
            {3, 2, 5},
            {3, 1, 1},
            {4, 3, -3}
        };

        int sourse = 0;

        FordBellmanAlgorithm(vertices, edges, edgeList, sourse);
    }

    public static void FordBellmanAlgorithm(int vertices, int edges, int[,] edgeList, int source)
    {
        int[] distance = new int[vertices];
        for (int i = 0; i < vertices; i++)
            distance[i] = int.MaxValue;
        distance[source] = 0;

        for (int i = 1; i <= vertices - 1; i++)
        {
            for (int j = 0; j < edges; j++)
            {
                int u = edgeList[j, 0];
                int v = edgeList[j, 1];
                int weight = edgeList[j, 2];

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    distance[v] = distance[u] + weight;
            }
        }

        for (int j = 0; j < edges; j++)
        {
            int u = edgeList[j, 0];
            int v = edgeList[j, 1];
            int weight = edgeList[j, 2];

            if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                Console.WriteLine("Граф содержит цикл с отрицательным весом");
        }

        Console.WriteLine("Расстояние от вершины до источника");
        for (int i = 0; i < vertices; i++)
            Console.WriteLine($"{i}\t\t {distance[i]}");
    }
}
