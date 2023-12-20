using System;
using System.Data;
using System.Linq;

class Andrey_and_Yasha
{
    static void Main()
    {
        Console.Write("Введите кол-во деталей: ");
        int N = int.Parse(Console.ReadLine()), schet = 0, a = 0, b = 0, k = 0, p=0;
        string[,] Array = new string[N, 4];
        string[,] Array_form = new string[2 * N, 3];
        int[] only_form = new int[2 * N];
        int[,] otvet = new int[N, 2];

        // ввод массива деталей
        for (int l = 0; l < N; l++)
        {
            Console.Write($"Введите строку для детали {l + 1} (20 символов): ");
            string input = Console.ReadLine().Replace(" ", "");

            for (int j = 0; j < 4; j++)
            {
                Array[l, j] = input.Substring(j * 5, 5);
            }
        }

        // Ввод массива форм
        for (int l = 0; l < 2 * N; l++)
        {
            Console.Write($"Введите строку для формы {l + 1} (15 символов): ");
            string input = Console.ReadLine().Replace(" ", "");

            for (int j = 0; j < 3; j++)
            {
                Array_form[l, j] = input.Substring(j * 5, 5);
            }
        }
        while (ZeroTrue(otvet))
        {
            for (int l = 0; l < N; l++)
            {
                schet = 0;
                int[] cashe = new int[N]; p = 0;
                for (int i = 0; i < 2 * N; i++)
                {
                    if (((Array[l, 0] == Array_form[i, 0]) && (Array[l, 2] == Array_form[i, 2])) && Array[l, 3] == Array_form[i, 1] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 2] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t)
                                && Array[l, 1] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i+1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p+1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 1] == Array_form[i, 2]) && (Array[l, 3] == Array_form[i, 0])) && Array[l, 2] == Array_form[i, 1] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 2] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t) 
                                && Array[l, 0] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 0] == Array_form[i, 2]) && (Array[l, 1] == Array_form[i, 1])) && Array[l, 2] == Array_form[i, 0] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 2] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t) 
                                && Array[l, 3] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 0] == Array_form[i, 1]) && (Array[l, 2] == Array_form[i, 0])) && Array[l, 3] == Array_form[i, 2] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 1] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 0] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t) 
                                && Array[l, 1] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 1] == Array_form[i, 0]) && (Array[l, 3] == Array_form[i, 2])) && Array[l, 2] == Array_form[i, 1] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 2] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 1] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t) 
                                && Array[l, 0] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 0] == Array_form[i, 1]) && (Array[l, 1] == Array_form[i, 2])) && Array[l, 2] == Array_form[i, 0] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 1] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 2] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t) 
                                && Array[l, 3] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2; 
                            }
                        }
                    }
                    if (((Array[l, 0] == new string(Array_form[i, 1].Reverse().ToArray())) && (Array[l, 1] == new string(Array_form[i, 2].Reverse().ToArray())) && Array[l, 3] == new string(Array_form[i, 0].Reverse().ToArray())) 
                        && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == Array_form[t, 2]) && (Array_form[i, 2] == Array_form[t, 0]) && (i != t) && Array[l, 2] == new string(Array_form[t, 1].Reverse().ToArray()) 
                                && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 1] == Array_form[i, 0]) && (Array[l, 3] == Array_form[i, 2])) && Array[l, 2] == Array_form[i, 1] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 2] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t)
                                && Array[l, 0] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 0] == Array_form[i, 2]) && (Array[l, 1] == Array_form[i, 1])) && Array[l, 2] == Array_form[i, 0] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == Array_form[t, 2]) && (Array_form[i, 2] == Array_form[t, 0]) && (i != t) && Array[l, 3] == Array_form[t, 1] && !(only_form.Contains(t + 1))
                                 && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 0] == Array_form[i, 1]) && (Array[l, 1] == Array_form[i, 0])) && Array[l, 3] == Array_form[i, 2] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == new string(Array_form[t, 0].Reverse().ToArray())) && (Array_form[i, 2] == new string(Array_form[t, 2].Reverse().ToArray())) && (i != t)
                                && Array[l, 2] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1)) && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 1] == Array_form[i, 2]) && (Array[l, 2] == Array_form[i, 1])) && Array[l, 3] == Array_form[i, 0] && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == Array_form[t, 2]) && (Array_form[i, 2] == Array_form[t, 0]) && (i != t) && Array[l, 0] == Array_form[t, 1] && !(only_form.Contains(t + 1))
                                 && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                    if (((Array[l, 0] == new string(Array_form[i, 0].Reverse().ToArray())) && (Array[l, 1] == new string(Array_form[i, 1].Reverse().ToArray())) && Array[l, 2] == new string(Array_form[i, 2].Reverse().ToArray()))
                        && !(only_form.Contains(i + 1)))
                    {
                        for (int t = 0; t < 2 * N; t++)
                        {
                            if ((Array_form[i, 0] == Array_form[t, 2]) && (Array_form[i, 2] == Array_form[t, 0]) && (i != t) && Array[l, 3] == new string(Array_form[t, 1].Reverse().ToArray()) && !(only_form.Contains(t + 1))
                                 && !(cashe.Contains(i + 1) && cashe.Contains(t + 1)))
                            {
                                schet += 1; a = i + 1; b = t + 1; cashe[p] = a; cashe[p + 1] = b; p += 2;
                            }
                        }
                    }
                }
                if (schet == 1) { only_form[k] = a; only_form[k + 1] = b; k += 2; otvet[l, 0] = a; otvet[l, 1] = b; }
            }

        }
        for (int t = 0; t < N; t++)
            Console.WriteLine($"Для детали {t + 1} формы: {otvet[t, 0]}    {otvet[t, 1]}");
    }
    public static bool ZeroTrue(int[,] array)
    {
        foreach (int element in array)
        {
            if (element == 0)
            {
                return true;
            }
        }

        return false;
    }

}
