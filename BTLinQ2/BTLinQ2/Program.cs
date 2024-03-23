using System;
using System.Collections.Generic;

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
        // Tạo một số vị trí công việc
        Position manager = new Position(1, "Manager", 50000);
        Position developer = new Position(2, "Developer", 40000);
        Position designer = new Position(3, "Designer", 45000);

        // Tạo một số phòng ban
        Department hrDepartment = new Department(1, "Human Resources");
        Department itDepartment = new Department(2, "Information Technology");

        // Tạo một số nhân viên
        Employee emp1 = new Employee(1, "John Doe", new DateTime(2020, 1, 1), manager);
        Employee emp2 = new Employee(2, "Jane Smith", new DateTime(2021, 5, 10), developer);
        Employee emp3 = new Employee(3, "Bob Johnson", new DateTime(2019, 8, 15), designer);

        // Thêm nhân viên vào phòng ban
        hrDepartment.Employees.Add(emp1);
        itDepartment.Employees.Add(emp2);
        itDepartment.Employees.Add(emp3);

        // Hiển thị thông tin
        Console.WriteLine("Employees in HR Department:");
        foreach (Employee emp in hrDepartment.Employees)
        {
            Console.WriteLine($"Name: {emp.Name}, Position: {emp.Position.Title}, Salary: {emp.Position.Salary}");
        }

        Console.WriteLine("\nEmployees in IT Department:");
        foreach (Employee emp in itDepartment.Employees)
        {
            Console.WriteLine($"Name: {emp.Name}, Position: {emp.Position.Title}, Salary: {emp.Position.Salary}");
        }
    }
}
