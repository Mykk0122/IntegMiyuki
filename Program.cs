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
                Console.WriteLine("--- Employee Management System ---");
                Console.WriteLine("1. Add/Update Employee\n2. View Employee\n3. Exit");
                string mainChoice = Console.ReadLine();

                if (mainChoice == "1") AddEmployee();
                else if (mainChoice == "2") ViewEmployee();
                else if (mainChoice == "3") break;
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Status: \n1.Hired \n2.Promoted \n3.Moving \n4.Removed");
            string sChoice = Console.ReadLine();

            Console.WriteLine("Type: \n1.New \n2.Senior \n3.Retired");
            string dChoice = Console.ReadLine();

            service.ProcessEmployee(name, sChoice, dChoice);

            Console.WriteLine("Saved! Press any key...");
            Console.ReadKey();
        }

        static void ViewEmployee()
        {
            Console.Write("Search Name: ");
            string name = Console.ReadLine();
            var emp = service.FetchEmployee(name);

            if (emp != null)
                Console.WriteLine($"Found: {emp.Name} | {emp.Status} | {emp.Details}");
            else
                Console.WriteLine("Employee not found.");

            Console.ReadKey();
        }
    }
}