using System;

class Pro_Andrey_Program
{
    static void Main()
    {
        int INF = int.MaxValue;
        int[,] graph = {
            { 0, 3, INF, 5 },
            { 2, 0, INF, 4 },
            { INF, 1, 0, INF },
            { INF, INF, 2, 0 }
        };

        int n = graph.GetLength(0);
        int[,] dist = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                dist[i, j] = graph[i, j];

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (dist[i, j] == INF)
                    Console.Write("INF ");
                else
                    Console.Write(dist[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
