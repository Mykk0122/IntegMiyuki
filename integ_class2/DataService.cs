using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using integ_class1;

namespace integ_class2
{
    public class DataService
    {
        private string jsonPath = "data.json";

        public List<EmployeeModel> GetAllFromJson()
        {
            if (!File.Exists(jsonPath)) return new List<EmployeeModel>();

            string json = File.ReadAllText(jsonPath);
         
            if (string.IsNullOrWhiteSpace(json)) return new List<EmployeeModel>();

            return JsonSerializer.Deserialize<List<EmployeeModel>>(json) ?? new List<EmployeeModel>();
        }


        public void SaveToJSON(EmployeeModel data)
        {
            var allEmployees = GetAllFromJson();


            var existing = allEmployees.FirstOrDefault(e => e.Name == data.Name);
            if (existing != null) allEmployees.Remove(existing);

            allEmployees.Add(data);

            string json = JsonSerializer.Serialize(allEmployees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);
        }

        public void SaveToDatabase(EmployeeModel data)
        {
            Console.WriteLine("Database Save Triggered (Simulated)");
        }
    }
}