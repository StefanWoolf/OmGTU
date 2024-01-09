class Program
{
    static void Main()
    {
        for (double number = Math.Round(Math.Sqrt(106732567)); number <= Math.Ceiling(Math.Sqrt(152673836)); number++)
        {
            double d = 0;
            int chet = 0;
            for (int del = 2; del < number; del++)
            {
                if (number * number % del == 0)
                {
                    d = number * number / del;
                    chet++;
                }
                if (chet > 1) continue;
            }
            if (chet == 1)
            {
                Console.WriteLine($"Hello, World!   {number * number} {d}");
            }
        }
    }
}