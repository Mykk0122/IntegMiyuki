using integ_class1;
using integ_class2;
using System.Collections.Generic; 
using System.Linq; 

namespace integ_class3
{
    public class AppService
    {
        private DataService _data = new DataService();

        public void ProcessEmployee(string name, string sChoice, string dChoice)
        {
            string status = sChoice switch { "1" => "Hired", "2" => "Promoted", "3" => "Moving", "4" => "Removed", _ => "Unknown" };
            string details = dChoice switch { "1" => "New", "2" => "Senior", "3" => "Retired", _ => "General" };

            var emp = new EmployeeModel { Name = name, Status = status, Details = details };

            _data.SaveToJSON(emp);
        }

       
        public EmployeeModel FetchEmployee(string name)
        {
           
            var allEmployees = _data.GetAllFromJson();

            return allEmployees.FirstOrDefault(e => e.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}