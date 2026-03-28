using System;
using integ_class3;

namespace IntegMiyuki
{
    internal class Program
    {
        static AppService service = new AppService();
        bool running = true;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Employee Management System ---");
                Console.WriteLine("[1.] Add/Update Employee\n[2.] View Employee\n[3.] Exit");
                Console.Write("Enter Choice: ");
                string mainChoice = Console.ReadLine();
                Console.WriteLine("--------------------");

                if (mainChoice == "1") AddEmployee();
                else if (mainChoice == "2") ViewEmployee();
                else if (mainChoice == "3") break;
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("--------------------");

            Console.WriteLine("Status: \n[1.]Hired \n[2.]Promoted \n[3.]Moving \n[4.]Removed");
            Console.Write("Enter Choice: ");
          
            string sChoice = Console.ReadLine();

            Console.WriteLine("--------------------");
            Console.WriteLine("Position: \n[1.]New \n[2.]Senior \n[3.]Retired");
          
            Console.Write("Enter Choice: ");
            string dChoice = Console.ReadLine();
          


            service.ProcessEmployee(name, sChoice, dChoice);

            Console.WriteLine("\nSaved successfully! Press any key...");
            Console.ReadKey();
        }

        static void ViewEmployee()
        {
            Console.Write("Search Name: ");
            string name = Console.ReadLine();
            var emp = service.FetchEmployee(name);

            if (emp != null)
                Console.WriteLine($"\nFound: {emp.Name} | {emp.Status} | {emp.Details}");
            else
                Console.WriteLine("\nEmployee not found.");

            Console.ReadKey();
        }
    }
}