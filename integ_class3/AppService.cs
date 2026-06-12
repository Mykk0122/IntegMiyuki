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

        public void ProcessEmployee(string name, string sChoice, string dChoice, decimal salary, string department)
        {
            if (sChoice == "3")
            {
                _dbLogic.Delete(name);
                _jsonLogic.Delete(name);
                Console.WriteLine($"\n[System] '{name}' deleted from SQL and JSON.");
                return;
            }

            string status = sChoice switch
            {
                "1" => "Hired",
                "2" => "Promoted",
                _ => "Unknown" 
            };

            string details = dChoice switch
            {
                "1" => "New",
                "2" => "Senior",
                "3" => "Retired",
                _ => "General"
            };

            var emp = new EmployeeModel
            {
                Name = name,
                Status = status,
                Details = details,
                Salary = salary,       // new imple to
                Department = department // assign
            };

            _dbLogic.Save(emp);
            _jsonLogic.Save(emp);

            Console.WriteLine($"\n[System] '{name}' successfully saved as {status} ({details}) in {department} with a salary of {salary:N2}.");
        }

        public EmployeeModel? FetchEmployee(string name)
        {
            return _dbLogic.GetAll()
                .FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<EmployeeModel> GetList()
        {
            return _dbLogic.GetAll();
        }
    }
}