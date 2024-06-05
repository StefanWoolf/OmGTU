using System;

class Andrey_Pro_Program
{
    static void Main()
    {
        int[,] matrix = {
            { int.MaxValue, 10, 15, 20 },
            { 10, int.MaxValue, 35, 25 },
            { 15, 35, int.MaxValue, 30 },
            { 20, 25, 30, int.MaxValue }
        };

        LittlesAlgoritm(matrix);
    }

    static void LittlesAlgoritm(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] path = new int[n + 1];
        bool[] visited = new bool[n];
        int totalCost = 0;
        int currentNode = 0;

        for (int step = 0; step < n; step++)
        {
            path[step] = currentNode;
            visited[currentNode] = true;

            int nextNode = -1;
            int minCost = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i] && matrix[currentNode, i] < minCost)
                {
                    minCost = matrix[currentNode, i];
                    nextNode = i;
                }
            }

            if (nextNode != -1)
            {
                totalCost += minCost;
                currentNode = nextNode;
            }
        }

        path[n] = path[0];
        totalCost += matrix[currentNode, path[0]];

        Console.WriteLine("Маршрут: " + string.Join(" -> ", path));
        Console.WriteLine("Общая стоимость: " + totalCost);
    }
}
