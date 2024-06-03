using System;
using System.Linq;
public class Movie
{
    public string Title { get; set; }
    public DateTime SessionTime { get; set; }
    public int Sold { get; set; }
    public int Free { get; set; }

    public double Workload
    {
        get
        {
            int Full = Sold + Free;
            if (Full == 0)
            {
                return 0;
            }

            return (double)Sold / Full * 100;
        }
    }

    public Movie(string title, DateTime sessionTime, int soldSeats, int freeSeats)
    {
        Title = title;
        SessionTime = sessionTime;
        Sold = soldSeats;
        Free = freeSeats;
    }
}

public class Program
{
    public static void Main()
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie("Победа", new DateTime(2024, 5, 5, 14, 30, 0), 30, 70),
            new Movie("Привет", new DateTime(2024, 5, 5, 16, 0, 0), 50, 50),
            new Movie("Любовь на веки", new DateTime(2024, 5, 5, 17, 45, 0), 80, 20),
            new Movie("Смешной полет в космос", new DateTime(2024, 5, 5, 18, 30, 0), 20, 80)
        };

        List<Movie> Workload50 = movies.Where(m => m.Workload < 50).ToList();

        List<Movie> sessionsAfter15 = movies.Where(m => m.SessionTime.TimeOfDay > new TimeSpan(15, 0, 0)).ToList();

        Console.WriteLine("Фильмы с занятостью мест < 50%:");
        foreach (var movie in Workload50)
            Console.WriteLine($"{movie.Title} ({movie.Workload}% занятости)");

        Console.WriteLine("\nФильмы с сеансами после 15:00:");
        foreach (var movie in sessionsAfter15)
            Console.WriteLine($"{movie.Title} (Начало сеанса: {movie.SessionTime:HH:mm})");
    }
}
