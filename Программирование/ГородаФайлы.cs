using System;
using System.IO;
using System.Linq;

public struct City
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int Population { get; set; }

    public City(string name, string country, int population)
    {
        Name = name;
        Country = country;
        Population = population;
    }
}

public class Program
{
    public static void Main()
    {
        // Считываем данные из файла
        string[] lines = File.ReadAllLines("cities.txt");
        List<City> cities = new List<City>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 3)
            {
                string name = parts[0];
                string country = parts[1];
                int population = int.Parse(parts[2]);
                cities.Add(new City(name, country, population));
            }
        }

        // Запрашиваем критерии у пользователя
        Console.Write("Введите символ для фильтрации по названиям городов: ");
        char cityInitial = Console.ReadLine()[0];

        Console.Write("Введите страну для фильтрации по странам: ");
        string countryFilter = Console.ReadLine();

        Console.Write("Введите минимальное количество жителей для фильтрации: ");
        int populationFilter = int.Parse(Console.ReadLine());

        // Фильтрация по городам, которые начинаются на заданный символ
        var citiesByInitial = (from city in cities 
                               where city.Name.StartsWith(cityInitial.ToString(), StringComparison.OrdinalIgnoreCase)
                               select city).ToList();
        File.WriteAllLines("cities_by_initial.txt", citiesByInitial.Select(c => $"{c.Name},{c.Country},{c.Population}"));

        // Фильтрация по стране
        var citiesByCountry = (from city in cities
                               where city.Country.Equals(countryFilter, StringComparison.OrdinalIgnoreCase)
                               select city).ToList();
        File.WriteAllLines("cities_by_country.txt", citiesByCountry.Select(c => $"{c.Name},{c.Country},{c.Population}"));

        // Фильтрация по количеству жителей
        var citiesByPopulation = (from city in cities
                                  where city.Population >= populationFilter
                                  select city).ToList();
        File.WriteAllLines("cities_by_population.txt", citiesByPopulation.Select(c => $"{c.Name},{c.Country},{c.Population}"));

        Console.WriteLine("Файлы успешно созданы.");
    }
}
