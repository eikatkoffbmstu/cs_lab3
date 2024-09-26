using System;
using System.Collections.Generic;

public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return this.Name == other.Name && this.Engine == other.Engine && this.MaxSpeed == other.MaxSpeed;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Engine, MaxSpeed);
    }
}

public class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
                throw new IndexOutOfRangeException("Index out of range.");
            return $"{cars[index].Name} - {cars[index].Engine}";
        }
    }

    public int Count => cars.Count;
}

class Program
{
    static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();
        
        catalog.AddCar(new Car("Toyota", "1", 240));
        catalog.AddCar(new Car("Honda", "2", 220));
        
        Console.WriteLine(catalog[0]); 
        Console.WriteLine(catalog[1]); 
        
        Car car1 = new Car("Ford", "3", 260);
        Car car2 = new Car("Ford", "3", 260);
        
        Console.WriteLine(car1.Equals(car2));
    }
}
