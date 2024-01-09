using System;

class Andrey_And_Yasha
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        string a = Console.ReadLine();
        int answer = 0;

        while (a != "")
        {
            string[] array = a.Split(new[] { stroka }, StringSplitOptions.None);
            answer += array.Length - 1;
            a = Console.ReadLine();
        }

        Console.WriteLine("кол-во вхождений " + answer);
    }
}
