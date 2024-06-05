using System;
using System.IO;

class Gear
{
    public int Num { get; }
    public int Teeth { get; }
    public int Rot { get; set; }
    public double Rpm { get; set; }

    public Gear(int num, int teeth, int rot, double rpm)
    {
        Num = num;
        Teeth = teeth;
        Rot = rot;
        Rpm = rpm;
    }
}

class Program
{
    static void Main()
    {
        string filename = "input_s1_08.txt";

        Dictionary<int, int> gearData = new Dictionary<int, int>();
        Dictionary<int, List<int>> connections = new Dictionary<int, List<int>>();

        using (StreamReader sr = new StreamReader(filename))
        {
            var firstLine = sr.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            int n = firstLine[0];
            int m = firstLine[1];

            for (int i = 0; i < n; i++)
            {
                var line = sr.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                int num = line[0];
                int teeth = line[1];
                gearData[num] = teeth;
                connections[num] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                var line = sr.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                connections[line[0]].Add(line[1]);
                connections[line[1]].Add(line[0]);
            }

            var frToLine = sr.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            int fr = frToLine[0];
            int to = frToLine[1];
            int stRotate = int.Parse(sr.ReadLine().Trim());

            Dictionary<int, (int rot, double rpm)> result = new Dictionary<int, (int, double)>();
            Queue<Gear> queue = new Queue<Gear>();
            queue.Enqueue(new Gear(fr, gearData[fr], stRotate, 1.0));

            while (queue.Count > 0)
            {
                var currentGear = queue.Dequeue();
                foreach (var next in connections[currentGear.Num])
                {
                    double nextRpm = Math.Round(currentGear.Teeth * currentGear.Rpm / gearData[next], 3);
                    int nextRot = -currentGear.Rot;

                    if (!result.ContainsKey(next) || (result[next].rot != nextRot || result[next].rpm != nextRpm))
                    {
                        result[next] = (nextRot, nextRpm);
                        queue.Enqueue(new Gear(next, gearData[next], nextRot, nextRpm));
                    }
                }
            }

            if (result.ContainsKey(to))
            {
                Console.WriteLine(1);
                Console.WriteLine(result[to].rot);
                Console.WriteLine(result[to].rpm);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}
