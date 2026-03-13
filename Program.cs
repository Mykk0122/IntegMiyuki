using System;
using System.Collections.Generic;


namespace IntegMiyuki
{
    internal class Program
    {
        static EmployeeManager manager = new EmployeeManager();
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("---Employee Management System---");
                Console.WriteLine("1. Add/Update Employee Status");
                Console.WriteLine("2. View Employee Status");
                Console.WriteLine("3. Exit");
                Console.Write("\n Please select an option (1-3):");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddOrUpdateEmployeeStatus();
                        break;
                    case "2":
                        ViewEmployeeStatus();
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                }



            }

        }

        static void AddOrUpdateEmployeeStatus()
        {
            Console.Write("\n Enter Employee Name:  ");
            string name = Console.ReadLine();
            Console.WriteLine("\n Enter Employee Status:  ");
            Console.WriteLine(" 1. Hired ");
            Console.WriteLine(" 2. Promoted ");
            Console.WriteLine(" 3. Moving  ");
            Console.WriteLine(" 4. Removed");
            Console.Write("Please Select: ");
            string choice = Console.ReadLine();

            string statusEm = choice switch
            {
                "1" => "Hired",
                "2" => "Promoted",
                "3" => "Moving",
                "4" => "Removed",
                _ => "Unknown"
            };

            Console.Write("Enter Details (e.g., Senior, New, Retired): ");
            string details = Console.ReadLine();

            manager.AddRecord(name, statusEm, details);

            Console.WriteLine("\nSuccess: {name} recorded as '{statusEm}'.");
            Console.ReadKey();
        }
        static void ViewEmployeeStatus()
        {
            Console.Write("\nEnter Employee Name: ");
            string name = Console.ReadLine();

            var record = manager.GetRecord(name);
            if (record != null)
            {
                Console.WriteLine($"\nEmployee '{name}' is currently '{record.Status}' ({record.Details}).");
            }
            else
            {
                Console.WriteLine($"\nNo record found for employee '{name}'.");
            }

            Console.WriteLine($"\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}


