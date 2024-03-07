using System;
using System.Collections.Generic;
using System.Linq;

class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
}

class Car : Vehicle
{
    public Car(string brand, int year, decimal price)
    {
        Brand = brand;
        Year = year;
        Price = price;
    }
}

class Truck : Vehicle
{
    public string Company { get; set; }

    public Truck(string brand, int year, decimal price, string company)
    {
        Brand = brand;
        Year = year;
        Price = price;
        Company = company;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>
        {
            new Car("Camry", 1995, 150000),
            new Car("Honda", 2000, 180000),
            new Car("Ford", 2010, 220000),
            new Car("Chevrolet", 2005, 190000),
            new Car("Hyundai", 2015, 260000)
        };

        List<Truck> trucks = new List<Truck>
        {
            new Truck("Volvo FH", 2012, 350000, "Volvo"),
            new Truck("AMG ", 2010, 400000, "Mercedes-Benz"),
            new Truck("Ford F-150", 2015, 500000, "MAN"),
         
        };

        Console.WriteLine("Chọn một trong các tùy chọn sau:");
        Console.WriteLine("1. Hiển thị các xe có giá trong khoảng 100.000 đến 250.000 và năm sản xuất > 1990.");
        Console.WriteLine("2. Gom các xe theo hãng sản xuất và tính tổng giá trị theo nhóm.");
        Console.WriteLine("3. Hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất.");
        Console.WriteLine("4. Hiển thị tên công ty chủ quản của Truck.");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Các xe có giá trong khoảng 100.000 đến 250.000 và năm sản xuất > 1990:");
                var filteredCars = cars.Where(car => car.Price >= 100000 && car.Price <= 250000 && car.Year > 1990);
                foreach (var car in filteredCars)
                {
                    Console.WriteLine($"- {car.Brand}, Giá: {car.Price}, Năm: {car.Year}");
                }
                break;

            case "2":
                Console.WriteLine("Các xe được nhóm theo hãng sản xuất và tính tổng giá trị theo nhóm:");
                var groupedCars = cars.GroupBy(car => car.Brand)
                                      .Select(group => new { Brand = group.Key, TotalPrice = group.Sum(car => car.Price) });
                foreach (var group in groupedCars)
                {
                    Console.WriteLine($"- {group.Brand}, Tổng giá trị: {group.TotalPrice}");
                }
                break;

            case "3":
                Console.WriteLine("Danh sách Truck theo thứ tự năm sản xuất mới nhất:");
                var sortedTrucks = trucks.OrderByDescending(truck => truck.Year);
                foreach (var truck in sortedTrucks)
                {
                    Console.WriteLine($"- {truck.Brand}, Năm sản xuất: {truck.Year}");
                }
                break;

            case "4":
                Console.WriteLine("Tên công ty chủ quản của Truck:");
                var truckCompanies = trucks.Select(truck => truck.Company);
                foreach (var company in truckCompanies)
                {
                    Console.WriteLine($"- {company}");
                }
                break;

            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                break;
        }

        Console.ReadLine();
    }
}