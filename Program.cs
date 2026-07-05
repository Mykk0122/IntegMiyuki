using System;
using integ_class3;

namespace IntegMiyuki
{
    internal class Program
    {
        static AppService service = new AppService();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Employee Management System ---");
                Console.WriteLine("[1] Add Employee\n[2] Update Employee\n[3] Delete Employee\n[4] Search Employee\n[5] Exit");
                Console.Write("\nEnter Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    case "2":
                    case "3":
                        HandleEmployeeAction(choice);
                        break;
                    case "4":
                        ViewEmployee();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void HandleEmployeeAction(string actionChoice)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            string status = "Unknown";
            string department = "N/A";
            decimal salary = 0;

            // Only ask for details if we aren't deleting (choice "3")
            if (actionChoice != "3")
            {
                status = GetStatusFromInput();

                Console.Write("Enter Department: ");
                department = Console.ReadLine();

                Console.Write("Enter Salary: ");
                while (!decimal.TryParse(Console.ReadLine(), out salary))
                {
                    Console.Write("Invalid input. Please enter a valid decimal for Salary: ");
                }
            }

            service.ProcessEmployee(name, actionChoice, status, salary, department);
            Console.WriteLine("\nOperation successful. Press any key to continue...");
            Console.ReadKey();
        }

        static string GetStatusFromInput()
        {
            while (true)
            {
                Console.WriteLine("\nPosition: [1] New, [2] Senior, [3] Retired");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": return "New";
                    case "2": return "Senior";
                    case "3": return "Retired";
                    default: Console.WriteLine("Invalid selection."); break;
                }
            }
        }

        static void ViewEmployee()
        {
            Console.Write("\nSearch Name: ");
            string name = Console.ReadLine();
            var emp = service.FetchEmployee(name);

            if (emp != null)
            {
                Console.WriteLine($"\nFound: {emp.Name}");
                Console.WriteLine($"Status: {emp.Status}");
                Console.WriteLine($"Department: {emp.Department}");
                Console.WriteLine($"Salary: {emp.Salary:C}"); // Uses Currency formatting
            }
            else
            {
                Console.WriteLine("\nEmployee not found.");
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}