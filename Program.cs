using System;
using integ_class3;

namespace IntegMiyuki
{
    internal class Program
    {
        static AppService service = new AppService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Employee Management System ---");
                Console.WriteLine("[1.] Add Employee");
                Console.WriteLine("[2.] Update Employee");
                Console.WriteLine("[3.] Delete Employee");
                Console.WriteLine("[4.] Search Employee");
                Console.WriteLine("[5.] Exit");
                Console.WriteLine("--------------------");
                Console.Write("Enter Choice: ");
                string mainChoice = Console.ReadLine();
                Console.WriteLine("--------------------");

                if (mainChoice == "1" || mainChoice == "2" || mainChoice == "3")
                    HandleEmployeeAction(mainChoice);
                else if (mainChoice == "4")
                    ViewEmployee();
                else if (mainChoice == "5")
                    break;
            }
        }

        static void HandleEmployeeAction(string actionChoice)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            string dChoice = "0";
            string department = string.Empty;
            decimal salary = 0;

            if (actionChoice != "3")
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Position: \n[1.] New \n[2.] Senior \n[3.] Retired");
                Console.Write("Enter Choice: ");
                dChoice = Console.ReadLine();

                Console.WriteLine("--------------------");
                Console.Write("Enter Department: ");
                department = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Salary: ");
                if (!decimal.TryParse(Console.ReadLine(), out salary))
                {
                    salary = 0; 
                }
            }

            service.ProcessEmployee(name, actionChoice, dChoice, salary, department);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void ViewEmployee()
        {
            Console.Write("Search Name: ");
            string name = Console.ReadLine();
            var emp = service.FetchEmployee(name);

            if (emp != null)
            {
                Console.WriteLine($"\nFound: {emp.Name}");
                Console.WriteLine($"Status: {emp.Status} ({emp.Details})");
                Console.WriteLine($"Department: {emp.Department}");
                Console.WriteLine($"Salary: {emp.Salary:N2}");
            }
            else
            {
                Console.WriteLine("\nEmployee not found.");
            }

            Console.ReadKey();
        }
    }
}