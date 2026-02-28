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
            Console.Write("\n Enter Employee Name:  ");
            string name = Console.ReadLine();
            Console.WriteLine("\n Enter Employee Status:  ");
            Console.WriteLine(" Hired ");
            Console.WriteLine(" Promoted ");
            Console.WriteLine(" Moving  ");
            Console.WriteLine(" Removed");
            Console.Write("Please Select: ");
            string status = Console.ReadLine();

            Console.WriteLine($"\n Employee '{name}' status updated to '{status}'.");
            string choice = Console.ReadLine();
            string statusEm = choice switch
            {
                "1" => "Hired",
                "2" => "Promoted",
                "3" => "Moving",
                "4" => "removed",
                _ => "Unknown"
            };
            Console.Write("Enter Status of Employee: ");
            string details = Console.ReadLine();


        }
        static void ViewEmployeeStatus()
            {
                Console.Write("\n Enter employee name");
                string name = Console.ReadLine();
                Console.WriteLine($"\n Employee '{name}' is Currently 'status'.");
                
                Console.WriteLine("\n Press any key to return to the main menu...");
                Console.ReadKey();
               


            }
        }
    }




