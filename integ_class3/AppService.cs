using System;
using System.Linq;
using System.Collections.Generic;
using integ_class1;
using integ_class2;

namespace integ_class3
{
    public class AppService
    {
        
        private IEmployeeData _dbLogic = new AccountDBData();
        private IEmployeeData _jsonLogic = new AccountJsonData();

        public void ProcessEmployee(string name, string sChoice, string dChoice)
        {
            string status = sChoice switch { "1" => "Hired", "2" => "Promoted", "3" => "Moving", "4" => "Removed", _ => "Unknown" };
            string details = dChoice switch { "1" => "New", "2" => "Senior", "3" => "Retired", _ => "General" };

            var emp = new EmployeeModel { Name = name, Status = status, Details = details };

         
            _dbLogic.Save(emp);
            _jsonLogic.Save(emp);

            Console.WriteLine("\n[System] Successfully synced to SQL Server and local JSON file.");
        }

        public EmployeeModel? FetchEmployee(string name)
        {
            return _dbLogic.GetAll()
                .FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<EmployeeModel> GetList()
        {
            // Usually, we return the Database list as the primary source
            return _dbLogic.GetAll();
        }
    }
}