using System.Collections;
using System.Collections.Generic;

class MainClass
{
    public static void Main()
    {

        List<List<int>> graphEdges = new List<List<int>>();
        string input;
        while (true)
        {
            Console.Write("Ввод: ");
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                break;

            string[] numbers = input.Split(' ');

            if (numbers.Length != 2)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, повторите.");
                continue;
            }

            if (!int.TryParse(numbers[0], out int num_1) ||
                !int.TryParse(numbers[1], out int num_2))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, повторите.");
                continue;
            }

            AddEdge(graphEdges, num_1, num_2);

        }


        Console.WriteLine("Рёбра графа:");
        PrintGraph(graphEdges);

        Console.WriteLine("Выберите метод:\n1. Глубины.\n2. Ширины.");
        input = Console.ReadLine();

        bool[] visited = new bool[graphEdges.Count + 1];
        switch (input)
        {
            case "1":
                for (int i = 0; i < graphEdges.Count; i++)
                {

                    DepthMethod_1(graphEdges, visited);

                }
                break;
            case "2":
                for (int i = 0; i < graphEdges.Count; i++)
                {
                    WidthMethod(i, graphEdges, visited);
                }
                break;
        }

    }
    static void AddEdge(List<List<int>> graph, int num_1, int num_2)
    {

        if (num_1 == num_2)
            return;

        while (graph.Count <= Math.Max(num_1, num_2))
        {
            graph.Add(new List<int>());
        }
        if (!graph[num_1].Contains(num_2))
        {
            graph[num_1].Add(num_2);
            graph[num_2].Add(num_1);

        }
    }

    static void PrintGraph(List<List<int>> graph)
    {
        for (int i = 0; i < graph.Count; i++)
        {
            Console.Write($"Вершина {i}: ");
            foreach (var edge in graph[i])
            {
                Console.Write($"{edge} ");
            }
            Console.WriteLine();
        }
    }

    public static void DepthMethod_1(List<List<int>> graphEdges, bool[] visited)
    {
        for (int i = 1; i < graphEdges.Count; ++i)
            if (!visited[i])
            {
                Console.WriteLine();
                DepthMethod_2(i, visited, graphEdges);
            }
    } 
    public static void DepthMethod_2(int i, bool[] visited, List<List<int>> graphEdges)
    {
        visited[i] = true;
        Console.Write(i + " ");

        foreach (int q in graphEdges[i])
            if (!visited[q])
                DepthMethod_2(q, visited, graphEdges);
    }


    public static void WidthMethod(int start, List<List<int>> graphEdges, bool[] visited)
    {
        string str="";
        Queue<int> queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            int peak = queue.Dequeue();
            str += $"{peak} ";
            foreach (int givePeak in graphEdges[peak])
            {
                if (!visited[givePeak])
                {
                    visited[givePeak] = true;
                    queue.Enqueue(givePeak);
                }
            }
        }
        if (str.Length != 2)
            Console.WriteLine(str);

    }
}