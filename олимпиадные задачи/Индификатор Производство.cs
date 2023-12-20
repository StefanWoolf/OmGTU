using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первую дату в формате DD.MM.YYYY:");
        string input1 = Console.ReadLine();
        int[] d1 = Array.ConvertAll(input1.Split('.'), int.Parse);
        DateTime day1 = new DateTime(d1[2], d1[1], d1[0]);

        Console.WriteLine("Введите вторую дату в формате DD.MM.YYYY:");
        string input2 = Console.ReadLine();
        int[] d2 = Array.ConvertAll(input2.Split('.'), int.Parse);

        Console.WriteLine("Введите первое число:");
        int first = int.Parse(Console.ReadLine());

        DateTime day2 = new DateTime(d2[2], d2[1], d2[0]);
        TimeSpan delta = day2 - day1;

        int last = first + delta.Days;
        double summ = (first + last) / 2.0 * (delta.Days + 1);

        Console.WriteLine(summ);
    }
}
