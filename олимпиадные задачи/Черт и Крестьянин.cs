using System;

class Andrey_And_Yasha
{
    static void Main()
    {
        Console.WriteLine("Введите MaxN:");
        int MaxN = int.Parse(Console.ReadLine());
        int answer = MaxN;

        for (int z = 2; z <= Math.Ceiling(Math.Log(MaxN, 2)) + 1; z++)
        {
            int n = (int)Math.Pow(2, z) - 1;
            int delitel = MaxN / n;
            answer += delitel;
        }

        Console.WriteLine(answer);
    }
}