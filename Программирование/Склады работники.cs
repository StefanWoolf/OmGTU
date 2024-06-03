using System;
using System.Linq;

public class Warehouse
{
    public string Article { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double PricePerUnit { get; set; }
    public string Location { get; set; }

    public Warehouse(string article, string name, string category, int quantity, double pricePerUnit, string location)
    {
        Article = article;
        Name = name;
        Category = category;
        Quantity = quantity;
        PricePerUnit = pricePerUnit;
        Location = location;
    }
}

public class Worker
{
    public int EmployeeNumber { get; set; }
    public string FullName { get; set; }
    public string ProductCategory { get; set; }
    public int ProducedQuantity { get; set; }
    public double PricePerUnit { get; set; }
    public double Salary { get; set; }
    public string Specialty { get; set; }

    public Worker(int employeeNumber, string fullName, string productCategory, int producedQuantity, double pricePerUnit, double salary, string specialty)
    {
        EmployeeNumber = employeeNumber;
        FullName = fullName;
        ProductCategory = productCategory;
        ProducedQuantity = producedQuantity;
        PricePerUnit = pricePerUnit;
        Salary = salary;
        Specialty = specialty;
    }
}

public class AndteyMolodets
{
    public static void Main()
    {
        List<Warehouse> warehouses = new List<Warehouse>
        {
            new Warehouse("A1", "Product1", "Category1", 100, 10, "Warehouse1"),
            new Warehouse("A2", "Product2", "Category1", 200, 15, "Warehouse1"),
            new Warehouse("B1", "Product3", "Category2", 150, 20, "Warehouse2"),
            new Warehouse("B2", "Product4", "Category2", 50, 25, "Warehouse2"),
            new Warehouse("C1", "Product5", "Category3", 300, 30, "Warehouse3"),
        };

        List<Worker> workers = new List<Worker>
        {
            new Worker(1, "Иванов Иван Иванович", "Category1", 10, 50, 200, "Швея"),
            new Worker(2, "Петров Петр Петрович", "Category2", 20, 30, 400, "Токарь"),
            new Worker(3, "Сидоров Сидор Сидорович", "Category1", 5, 100, 200, "Швея"),
            new Worker(4, "Александров Александр Александрович", "Category3", 8, 40, 300, "Слесарь"),
            new Worker(5, "Михайлов Михаил Михайлович", "Category2", 15, 20, 100, "Токарь")
        };

        //Задание 1 Работа со складами

        var totalValuePerWarehouse = warehouses.GroupBy(w => w.Location).Select(g => new {Location = g.Key, TotalValue = g.Sum(w => w.Quantity * w.PricePerUnit)});

        Console.WriteLine("Объем товара в денежном эквиваленте на каждом складе:");
        foreach (var item in totalValuePerWarehouse)
            Console.WriteLine($"Склад: {item.Location}, Общая стоимость: {item.TotalValue}");


        //макс цена
        var maxPriceCategory = warehouses
            .GroupBy(w => new { w.Location, w.Category }).Select(g => new{Location = g.Key.Location,Category = g.Key.Category,MaxPrice = g.Max(w => w.PricePerUnit)});

        Console.WriteLine("\nМаксимальная цена товара по каждой категории (для каждого склада):");
        foreach (var item in maxPriceCategory)
            Console.WriteLine($"Склад: {item.Location}, Категория: {item.Category}, Максимальная цена: {item.MaxPrice}");

        // сред цена
        var avgPricePerCategory = warehouses.GroupBy(w => w.Category).Select(g => new {Category = g.Key,AvgPrice = g.Average(w => w.PricePerUnit)});

        Console.WriteLine("\nСредняя цена товаров для каждой категории:");
        foreach (var item in avgPricePerCategory)
            Console.WriteLine($"Категория: {item.Category}, Средняя цена: {item.AvgPrice}");

        // самый дешовый товар
        var minPerWarehouse = warehouses.GroupBy(w => w.Location).Select(g => new{Location = g.Key,CheapestProduct = g.OrderBy(w => w.PricePerUnit).FirstOrDefault()});

        Console.WriteLine("\nСамый дешевый товар по каждому складу:");
        foreach (var item in minPerWarehouse)
            Console.WriteLine($"Склад: {item.Location}, Самый дешевый товар: {item.CheapestProduct.Name}, Цена: {item.CheapestProduct.PricePerUnit}");

        //общ кол товаров
        var allPerWarehouse = warehouses.GroupBy(w => new { w.Location, w.Category }).Select(g => new{Location = g.Key.Location,Category = g.Key.Category,TotalQuantity = g.Sum(w => w.Quantity)});

        Console.WriteLine("\nОбщее количество товаров по категории (по каждому складу):");
        foreach (var item in allPerWarehouse)
            Console.WriteLine($"Склад: {item.Location}, Категория: {item.Category}, Общее количество: {item.TotalQuantity}");


        //Задание 2 работникик

        var underWorkersCount = workers.Count(w => w.Salary < w.ProducedQuantity * w.PricePerUnit);
        Console.WriteLine($"\nКоличество работников, которые получают зарплату меньше, чем вырабатывают продукцию: {underWorkersCount}");

        var totalPerCategory = workers.GroupBy(w => w.ProductCategory).Select(g => new{Category = g.Key,TotalProduced = g.Sum(w => w.ProducedQuantity)});
        Console.WriteLine("\nКоличество единиц произведенной продукции по каждой категории:");
        foreach (var item in totalPerCategory)
            Console.WriteLine($"Категория: {item.Category}, Общее количество: {item.TotalProduced}");


        double totalValueProduced = workers.Sum(w => w.ProducedQuantity * w.PricePerUnit);
        Console.WriteLine($"\nСуммарный денежный эквивалент произведенной продукции по всем товарам: {totalValueProduced}");


        var WorkersCount50 = workers.Count(w => w.Salary > (w.ProducedQuantity * w.PricePerUnit) * 0.5);
        Console.WriteLine($"\nКоличество работников, которые получают больше 50 процентов от суммы производимого продукта: {WorkersCount50}");
    }
}
