namespace IntegMiyuki
{
    internal class Program
    {
      
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
            Console.Write("\n Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.Write(" Enter Employee Status (Active/Inactive): ");
            string status = Console.ReadLine();

            Console.WriteLine($"\n Employee '{name}' status updated to '{status}'.");
            Console.WriteLine(" Press any key to return to the main menu...");
            Console.ReadKey();
            string choice = Console.ReadLine();
            string statusEm = choice switch
            {
                "1" => "Active",
                "2" => "Inactive",
                _ => "Unknown"
            };
            Console.Write("Enter Status of Employee: ");
            string details = Console.ReadLine();

        }

        static void ViewEmployeeStatus()
        {
            Console.Write("\n Enter employee name");
            {

            }
            Console.WriteLine("\n Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }

}

