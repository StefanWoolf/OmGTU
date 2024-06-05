using System.Globalization;

class hvhvhvh
{
    static void Main()
    {
        int[,] graph = new int[,]
        {{ -1, -1, -1, -1, -1, -1,-1},
        { -1,int.MaxValue ,int.MaxValue , -1,int.MaxValue , -1,-1},
        { -1, int.MaxValue, -1, int.MaxValue, int.MaxValue, int.MaxValue,-1},
        { -1, int.MaxValue, int.MaxValue, -1, -1, -1,-1},
        { -1, int.MaxValue, -1, -1, -1, -1,-1},
        { -1, int.MaxValue, int.MaxValue, int.MaxValue, -1, int.MaxValue,-1},
        { -1, -1, -1, -1, -1, -1,-1},};

        int[,] graph2 = new int[,]
        {{ -1, -1, -1, -1, -1, -1,-1},
        { -1,int.MaxValue ,int.MaxValue , -1,int.MaxValue , -1,-1},
        { -1, int.MaxValue, -1, int.MaxValue, int.MaxValue, int.MaxValue,-1},
        { -1, int.MaxValue, int.MaxValue, -1, -1, -1,-1},
        { -1, int.MaxValue, -1, -1, -1, int.MaxValue,-1},
        { -1, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue,-1},
        { -1, -1, -1, -1, -1, -1,-1},};

        Console.WriteLine("Добро пожаловать в ВОЛНОВОЙ АЛГОРИТМ!11!\nУ вас есть поле 5х5 клеток.");
        bool flag = true;
        string[] numbers = { "22", "11" };
        while (flag)
        {
            Console.Write("Введите клетку с которой хотите начать: ");
            numbers = Console.ReadLine().Split(' ');
            if (graph[int.Parse(numbers[0]), int.Parse(numbers[1])] != -1)
            { graph[int.Parse(numbers[0]), int.Parse(numbers[1])] = 0; flag = false; }
            else Console.WriteLine("Yacheika zanyata :(");
        }
        flag = true;
        while (flag)
        {
            Console.Write("Введите клетку в которой хотите закончить: ");
            numbers = Console.ReadLine().Split(' ');
            if ((graph[int.Parse(numbers[0]), int.Parse(numbers[1])] != -1) && graph[int.Parse(numbers[0]), int.Parse(numbers[1])] != 0)
            { graph[int.Parse(numbers[0]), int.Parse(numbers[1])] = -2; flag = false; }
            else Console.WriteLine("Yacheika zanyata :(");
        }


        // Алгоритм
        int num = 0;
        while (graph[int.Parse(numbers[0]), int.Parse(numbers[1])] == -2 && !flag)
        {
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                {
                    if (graph[i, j] == num)
                    {
                        if (((graph[i - 1, j - 1] != -1) && (graph[i - 1, j - 1] > num + 1)) || graph[i - 1, j - 1] == -2) graph[i - 1, j - 1] = num + 1;
                        if (((graph[i - 1, j] != -1) && (graph[i - 1, j] > num + 1)) || graph[i - 1, j] == -2) graph[i - 1, j] = num + 1;
                        if (((graph[i - 1, j + 1] != -1) && (graph[i - 1, j + 1] > num + 1)) || graph[i - 1, j + 1] == -2) graph[i - 1, j + 1] = num + 1;
                        if (((graph[i, j - 1] != -1) && (graph[i, j - 1] > num + 1)) || graph[i, j - 1] == -2) graph[i, j - 1] = num + 1;
                        if (((graph[i, j + 1] != -1) && (graph[i, j + 1] > num + 1)) || graph[i, j + 1] == -2) graph[i, j + 1] = num + 1;
                        if (((graph[i + 1, j - 1] != -1) && (graph[i + 1, j] > num + 1)) || graph[i + 1, j - 1] == -2) graph[i + 1, j - 1] = num + 1;
                        if (((graph[i + 1, j] != -1) && (graph[i + 1, j] > num + 1)) || graph[i + 1, j] == -2) graph[i + 1, j] = num + 1;
                        if (((graph[i + 1, j + 1] != -1) && (graph[i + 1, j + 1] > num + 1)) || graph[i + 1, j + 1] == -2) graph[i + 1, j + 1] = num + 1;

                    }
                }
            num += 1;
            flag = true;
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                    if (graph[i, j] != graph2[i, j])
                    {
                        graph2[i, j] = graph[i, j];
                        flag = false;
                    }
        }

        Console.WriteLine($"Алгоритм закончил свою работу!");
        if (graph[int.Parse(numbers[0]), int.Parse(numbers[1])] != -2)
        {
            Console.WriteLine($"Кол-во шагов до конца {graph[int.Parse(numbers[0]), int.Parse(numbers[1])]}");
            Console.WriteLine($"index:{numbers[0]} {numbers[1]}    : {graph[int.Parse(numbers[0]), int.Parse(numbers[1])]}");
            while (graph[int.Parse(numbers[0]), int.Parse(numbers[1])] != 0)
            {
                flag = false;
                for (int i = int.Parse(numbers[0]) - 1; i <= int.Parse(numbers[0]) + 1; i++)
                {
                    for (int j = int.Parse(numbers[1]) - 1; j <= int.Parse(numbers[1]) + 1; j++)
                        if (graph[int.Parse(numbers[0]), int.Parse(numbers[1])] == graph[i, j] + 1)
                        {
                            numbers[0] = $"{i}"; numbers[1] = $"{j}";
                            Console.WriteLine($"index:{numbers[0]} {numbers[1]}    : {graph[int.Parse(numbers[0]), int.Parse(numbers[1])]}");
                            flag = true;
                            break;
                        }
                    if (flag) break;
                }


            }
        }
        else
            Console.WriteLine("Нет прохода(((");
        
    }
}