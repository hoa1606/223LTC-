using System;
using System.Collections.Generic;
using System.Linq;

public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }

    public Department(int departmentId, string name)
    {
        DepartmentId = departmentId;
        Name = name;
        Employees = new List<Employee>();
    }
}

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public DateTime HireDate { get; set; }
    public Position Position { get; set; }

    public Employee(int employeeId, string name, DateTime hireDate, Position position)
    {
        EmployeeId = employeeId;
        Name = name;
        HireDate = hireDate;
        Position = position;
    }
}

public class Position
{
    public int PositionId { get; set; }
    public string Title { get; set; }
    public double Salary { get; set; }

    public Position(int positionId, string title, double salary)
    {
        PositionId = positionId;
        Title = title;
        Salary = salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo danh sách các vị trí công việc
        List<Position> positions = new List<Position>
        {
            new Position(1, "Manager", 50000),
            new Position(2, "Developer", 40000),
            new Position(3, "Designer", 45000)
        };

        // Tạo danh sách các phòng ban
        List<Department> departments = new List<Department>
        {
            new Department(1, "Human Resources"),
            new Department(2, "Information Technology")
        };

        // Tạo danh sách các nhân viên
        List<Employee> employees = new List<Employee>
        {
            new Employee(1, "John Doe", new DateTime(1985, 10, 1), positions[0]), // John Doe, Manager, HR
            new Employee(2, "Jane Smith", new DateTime(1990, 5, 10), positions[1]), // Jane Smith, Developer, IT
            new Employee(3, "Bob Johnson", new DateTime(1980, 8, 15), positions[2]), // Bob Johnson, Designer, IT
            new Employee(4, "Alice Brown", new DateTime(1988, 3, 20), positions[0]), // Alice Brown, Manager, IT
        };

        // Gán nhân viên vào phòng ban tương ứng
        departments[0].Employees.Add(employees[0]); // John Doe to HR
        departments[1].Employees.Add(employees[1]); // Jane Smith to IT
        departments[1].Employees.Add(employees[2]); // Bob Johnson to IT
        departments[1].Employees.Add(employees[3]); // Alice Brown to IT

        // Nhập các yêu cầu tìm kiếm từ bàn phím
        Console.WriteLine("Nhập từ khóa tìm kiếm:");
        string keyword = Console.ReadLine();
        Console.WriteLine("Nhập tuổi từ:");
        int minAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhập tuổi đến:");
        int maxAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhập vị trí:");
        string positionKeyword = Console.ReadLine();
        Console.WriteLine("Nhập phòng ban:");
        string departmentKeyword = Console.ReadLine();

        // Tìm và in ra kết quả từ các yêu cầu tìm kiếm
        var searchResult = employees.Where(emp =>
            (emp.Name.Contains(keyword) || emp.Position.Title.Contains(keyword) || emp.Position.Title.Contains(keyword)) &&
            (DateTime.Now.Year - emp.HireDate.Year >= minAge && DateTime.Now.Year - emp.HireDate.Year <= maxAge) &&
            (positionKeyword == "" || emp.Position.Title.Contains(positionKeyword)) &&
            (departmentKeyword == "" || emp.Position.Title.Contains(departmentKeyword))
        );

        Console.WriteLine("\nKết quả tìm kiếm:");
        foreach (var employee in searchResult)
        {
            Console.WriteLine($"Tên: {employee.Name}, Tuổi: {DateTime.Now.Year - employee.HireDate.Year}, Vị trí: {employee.Position.Title}, Phòng ban: {departments.FirstOrDefault(dep => dep.Employees.Contains(employee))?.Name}");
        }
    }
}
