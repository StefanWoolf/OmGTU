using System;
using System.IO;
using System.Linq;

public class Tyazhelo
{
    public static void Main()
    {
        //Задание 1
        string file1 = "file1.txt";
        string file2 = "file2.txt";
        string fileR = "result.txt";

        SortedFiles(file1, file2, fileR);
        Console.WriteLine("Слияние файлов завершено. Результат записан в result.txt.");

        //задание 2
        string inputFilePath = "fileA.txt";
        string result = FindA(inputFilePath);
        Console.WriteLine($"Строка с наименьшей длиной подпослед.... из символов a: {result}");
    }

    public static void SortedFiles(string file1, string file2, string fileR)
    {
        //ВОТ эти юзинги подсмотрел Крутая вещь :))
        using (StreamReader reader1 = new StreamReader(file1))
        using (StreamReader reader2 = new StreamReader(file2))
        using (StreamWriter writer = new StreamWriter(fileR))
        {
            string line1 = reader1.ReadLine();
            string line2 = reader2.ReadLine();

            while (line1 != null && line2 != null)
            {
                int value1 = int.Parse(line1);
                int value2 = int.Parse(line2);

                if (value1 < value2)
                {
                    writer.WriteLine(value1);
                    line1 = reader1.ReadLine();
                }
                else
                {
                    writer.WriteLine(value2);
                    line2 = reader2.ReadLine();
                }
            }

            while (line1 != null)
            {
                writer.WriteLine(line1);
                line1 = reader1.ReadLine();
            }

            while (line2 != null)
            {
                writer.WriteLine(line2);
                line2 = reader2.ReadLine();
            }
        }
    }
    //задание 2
    public static string FindA(string filePath)
    {
        string shortestLine = null;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int minLength = GetMinLength(line, 'a');
                if (shortestLine == null || minLength < GetMinLength(shortestLine, 'a'))
                    shortestLine = line;
            }
        }

        return shortestLine;
    }

    public static int GetMinLength(string str, char c)
    {
        int minLength = int.MaxValue;
        int currentLength = 0;
        bool inSequence = false;

        foreach (char ch in str)
        {
            if (ch == c)
                if (!inSequence)
                {
                    inSequence = true;
                    currentLength = 1;
                }
                else
                    currentLength++;
            else if (inSequence)
            {
                if (currentLength < minLength)
                    minLength = currentLength;
                inSequence = false;
            }
        }

        if (inSequence && currentLength < minLength)
            minLength = currentLength;

        if (minLength == int.MaxValue)
            return 0;
        else
            return minLength;
    }
}
