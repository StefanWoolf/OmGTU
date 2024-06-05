using System;
using System.IO;

class KITI
{
    static void Main()
    {

        string fileContent = File.ReadAllText("input_s1_09.txt").Trim();
        string[] wordsArray = fileContent.Split(' ');

        List<string> circularSequence = new List<string>();
        int midIndex = wordsArray.Length / 2;

        if (wordsArray.Length % 2 == 0)
        {
            circularSequence.Add(wordsArray[midIndex]);
            for (int i = 1; i <= midIndex; i++)
            {
                circularSequence.Add(wordsArray[midIndex - i]);
                if (i < midIndex)
                {
                    circularSequence.Add(wordsArray[midIndex + i]);
                }
            }
        }
        else
        {
            midIndex = (wordsArray.Length - 1) / 2;
            circularSequence.Add(wordsArray[midIndex]);
            for (int i = 1; i <= midIndex; i++)
            {
                circularSequence.Add(wordsArray[midIndex - i]);
                circularSequence.Add(wordsArray[midIndex + i]);
            }
        }

        List<string> palindromes = new List<string>();

        foreach (string word in circularSequence)
        {
            string palindrome = "";
            int wordMidIndex = word.Length / 2;

            if (word.Length % 2 == 0)
            {
                palindrome += word[wordMidIndex];
                for (int i = 1; i <= wordMidIndex; i++)
                {
                    palindrome += word[wordMidIndex - i];
                    if (i < wordMidIndex)
                    {
                        palindrome += word[wordMidIndex + i];
                    }
                }
            }
            else
            {
                wordMidIndex = (word.Length - 1) / 2;
                palindrome += word[wordMidIndex];
                for (int i = 1; i <= wordMidIndex; i++)
                {
                    palindrome += word[wordMidIndex - i];
                    palindrome += word[wordMidIndex + i];
                }
            }
            palindromes.Add(palindrome);
        }

        string result = string.Join(" ", palindromes);
        Console.WriteLine(result);
    }
}
