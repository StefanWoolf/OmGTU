using System.Collections.Generic;
using System;
class Andrey_And_Yasha
{
    static void Main()
    {
        double n = 0,maxd = 0,time = 0,curd=0, skorost = 0;
        int voshod, zakat, stoptochki, days = 0;
        Console.Write("Введите длину пути: "); n = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите скорость туристов: "); skorost = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите количество остановок"); stoptochki = Convert.ToInt32(Console.ReadLine());
        
        double[] d = new double[stoptochki + 2];
        d[0] = 0;
        d[stoptochki + 1] = n;
        List<int> ost = new List<int>();

        Console.Write("Введите время восхода (hh mm): ");
        string[] input_voshod = Console.ReadLine().Split();
        voshod = Convert.ToInt32(input_voshod[0]) * 60 + Convert.ToInt32(input_voshod[1]);
        
        Console.Write("Введите время захода (hh mm): ");
        string[] input_zakat = Console.ReadLine().Split();
        zakat = Convert.ToInt32(input_zakat[0]) * 60 + Convert.ToInt32(input_zakat[1]);
        time = (zakat - voshod) / 60; maxd = skorost * time;
        
        Console.Write("Введите расстояние до каждого пункта: ");
        curd += maxd;
        for (int i = 1; i < stoptochki + 1; i++)
        {
            d[i] = Convert.ToDouble(Console.ReadLine());
        }
        for (int i = 1; i < stoptochki + 2; i++)
        {
            if (d[i] > curd)
            {
                days++;
                curd = d[i - 1];
                curd += maxd;
                ost.Add(i - 1);
            }
        }
        Console.WriteLine("Дней в пути: " + days);
        for (int i = 0; i < ost.Count; i++)
        {
            Console.WriteLine("Сделано остановок: " + ost[i]);
        }
    }
}