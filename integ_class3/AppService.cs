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

        public void ProcessEmployee(string name, string status, string details, decimal salary, string department)
        {
            var emp = new EmployeeModel
            {
                Name = name,
                Status = status,
                Details = details,
                Salary = salary,
                Department = department
            };

            _dbLogic.Save(emp);
            _jsonLogic.Save(emp);

            Console.WriteLine($"\n[System] '{name}' successfully saved as {status} ({details}).");
        }

        
        public void DeleteEmployee(string name)
        {
            _dbLogic.Delete(name);
            _jsonLogic.Delete(name);
            Console.WriteLine($"\n[System] '{name}' deleted from SQL and JSON.");
        }

        public EmployeeModel? FetchEmployee(string name)
        {
            var allEmployees = _dbLogic.GetAll();
            return allEmployees.FirstOrDefault(e => 
                e.Name != null && e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<EmployeeModel> GetList()
        {
            return _dbLogic.GetAll();
        }
    }
}