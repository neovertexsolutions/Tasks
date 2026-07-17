using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class Employee
    {
        
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        // Constructor to initialize Employee properties
        public Employee(int id, string name, string department, double salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>(); 

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("//**/*/*/*/*/***/*/**/*/*/*/*/*/*//");
                Console.WriteLine(" EMPLOYEE MANAGEMENT SYSTEM ");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Salary");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;

                    case 2:
                        ViewEmployees();
                        break;

                    case 3:
                        SearchEmployee();
                        break;

                    case 4:
                        UpdateSalary();
                        break;

                    case 5:
                        DeleteEmployee();
                        break;

                    case 6:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        Pause();
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Department: ");
            string department = Console.ReadLine();
            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            employees.Add(new Employee(id, name, department, salary));
            Console.WriteLine("Employee Added Successfully!");
            Pause();
        }

        static void ViewEmployees()
        {
            Console.WriteLine("\nEmployee List:");

            if (employees.Count == 0)
            {
                Console.WriteLine("No Employee Records Found.");
            }
            else
            {
                foreach (Employee emp in employees)
                {
                    Console.WriteLine("//////**/*/*/**/***//////");
                    Console.WriteLine($"ID : {emp.Id}");
                    Console.WriteLine($"Name: {emp.Name}");
                    Console.WriteLine($"Department : {emp.Department}");
                    Console.WriteLine($"Salary: {emp.Salary}");
                }
            }

            Pause();
        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to Search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine("\nEmployee Found:");
                Console.WriteLine($"ID: {emp.Id}");
                Console.WriteLine($"Name: {emp.Name}");
                Console.WriteLine($"Department: {emp.Department}");
                Console.WriteLine($"Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee Not Found!");
            }

            Pause();
        }

        static void UpdateSalary()
        {
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.Write("Enter New Salary: ");
                double newSalary = Convert.ToDouble(Console.ReadLine());

                emp.Salary = newSalary;

                Console.WriteLine("Salary Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Employee Not Found!");
            }

            Pause();
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Employee Not Found!");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }
    }
}