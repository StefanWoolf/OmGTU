using System;

// Класс Автомобиль
public class Car
{
    public string Model { get; set; }
    public bool Clean { get; set; }

    public Car(string model)
    {
        Model = model;
        Clean = false; // Новые машины грязные по умолчанию
    }

    public override string ToString()
    {
        return $"{Model} - {(Clean ? "Чистая" : "Грязная")}";
    }
}

public class Garage
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void ShowCars()
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    public List<Car> GetCars()
    {
        return cars;
    }
}

public class CarWash
{
    public void WashCar(Car car)
    {
        car.Clean = true;
        Console.WriteLine($"{car.Model} была вымыта.");
    }
}

public delegate void CarWashDelegate(Car car);

public class Program
{
    public static void Main()
    {

        Car car1 = new Car("Toyota");
        Car car2 = new Car("Ford");
        Car car3 = new Car("Tesla");
        Car car4 = new Car("Honda");
        Car car5 = new Car("BMW");
        Car car6 = new Car("Mercedes");
        Car car7 = new Car("Audi");
        Car car8 = new Car("Volkswagen");
        Car car9 = new Car("Nissan");
        Car car10 = new Car("Chevrolet");


        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);
        garage.AddCar(car4);
        garage.AddCar(car5);
        garage.AddCar(car6);
        garage.AddCar(car7);
        garage.AddCar(car8);
        garage.AddCar(car9);
        garage.AddCar(car10);


        CarWash carWash = new CarWash();

 
        CarWashDelegate washDelegate = carWash.WashCar;

        Console.WriteLine("Состояние автомобилей до мойки:");
        garage.ShowCars();


        List<Car> cars = garage.GetCars();
        Console.WriteLine("\nМойка машин:");
        foreach (var car in cars)
            washDelegate(car);

        Console.WriteLine("\nСостояние автомобилей после мойки:");
        garage.ShowCars();
    }
}
