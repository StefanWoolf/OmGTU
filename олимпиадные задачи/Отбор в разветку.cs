using System;

class Andrey_And_Yasha
{
    static void Main()
    {
        Console.WriteLine("Введите число:");
        int lot = int.Parse(Console.ReadLine());
        int result = Recursion(lot);
        Console.WriteLine(result);
    }

    static int Recursion(int lot)
    {
        if (lot == 3)
        {
            return 1;
        }
        else if (lot < 3 || lot == 4)
        {
            return 0;
        }
        return Recursion(lot / 2) + Recursion((int)Math.Ceiling((double)lot / 2));
    }
}
