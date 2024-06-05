using System;
using System.IO;

class Program
{
    static (double, double) Rotate(double primary, double secondary, int steps, double lowerBound, double upperBound)
    {
        while (steps != 0)
        {
            if (primary == lowerBound && secondary == lowerBound)
            {
                secondary += 1;
            }
            else if (primary == upperBound && secondary == upperBound)
            {
                secondary -= 1;
            }
            else if (primary == lowerBound && secondary == upperBound)
            {
                primary += 1;
            }
            else if (primary == upperBound && secondary == lowerBound)
            {
                primary -= 1;
            }
            else if (primary == lowerBound && secondary < upperBound)
            {
                secondary += 1;
            }
            else if (secondary == upperBound && primary < upperBound)
            {
                primary += 1;
            }
            else if (primary == upperBound && secondary > lowerBound)
            {
                secondary -= 1;
            }
            else if (secondary == lowerBound && primary > lowerBound)
            {
                primary -= 1;
            }
            steps -= 1;
        }
        return (primary, secondary);
    }

    static void Main()
    {
        string filename = "input_s1_15.txt";
        using (StreamReader file = new StreamReader(filename))
        {
            var firstLine = file.ReadLine().Split();
            int n = int.Parse(firstLine[0]);
            int m = int.Parse(firstLine[1]);
            var coordLine = file.ReadLine().Split();
            double coordX = double.Parse(coordLine[0]);
            double coordY = double.Parse(coordLine[1]);
            double coordZ = double.Parse(coordLine[2]);
            double center = (n - 1) / 2.0 + 1;

            for (int i = 0; i < m; i++)
            {
                var line = file.ReadLine().Split();
                string axis = line[0];
                int row = int.Parse(line[1]);
                int direction = int.Parse(line[2]);

                if (axis == "X" && coordX == row)
                {
                    double maxDistance = Math.Max(Math.Abs(coordY - center), Math.Abs(coordZ - center));
                    if (maxDistance == 0) continue;
                    int steps = (int)(maxDistance / 0.5);
                    double lowerBound = center - maxDistance;
                    double upperBound = center + maxDistance;
                    if (direction == 1)
                    {
                        (coordY, coordZ) = Rotate(coordY, coordZ, steps, lowerBound, upperBound);
                    }
                    else
                    {
                        (coordZ, coordY) = Rotate(coordZ, coordY, steps, lowerBound, upperBound);
                    }
                }
                else if (axis == "Y" && coordY == row)
                {
                    double maxDistance = Math.Max(Math.Abs(coordX - center), Math.Abs(coordZ - center));
                    if (maxDistance == 0) continue;
                    int steps = (int)(maxDistance / 0.5);
                    double lowerBound = center - maxDistance;
                    double upperBound = center + maxDistance;
                    if (direction == 1)
                    {
                        (coordX, coordZ) = Rotate(coordX, coordZ, steps, lowerBound, upperBound);
                    }
                    else
                    {
                        (coordZ, coordX) = Rotate(coordZ, coordX, steps, lowerBound, upperBound);
                    }
                }
                else if (axis == "Z" && coordZ == row)
                {
                    double maxDistance = Math.Max(Math.Abs(coordX - center), Math.Abs(coordY - center));
                    if (maxDistance == 0) continue;
                    int steps = (int)(maxDistance / 0.5);
                    double lowerBound = center - maxDistance;
                    double upperBound = center + maxDistance;
                    if (direction == 1)
                    {
                        (coordX, coordY) = Rotate(coordX, coordY, steps, lowerBound, upperBound);
                    }
                    else
                    {
                        (coordY, coordX) = Rotate(coordY, coordX, steps, lowerBound, upperBound);
                    }
                }
            }

            Console.WriteLine($"{coordX} {coordY} {coordZ}");
        }
    }
}
