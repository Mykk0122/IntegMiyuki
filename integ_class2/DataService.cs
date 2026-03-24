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
        private string _jsonFileName = "data.json";

        public List<EmployeeModel> GetAllFromJson()
        {
            if (!File.Exists(_jsonFileName)) return new List<EmployeeModel>();

            using (var inputStream = File.OpenRead(_jsonFileName))
            {
                if (inputStream.Length == 0) return new List<EmployeeModel>();
                return JsonSerializer.Deserialize<List<EmployeeModel>>(inputStream) ?? new List<EmployeeModel>();
            }
        }

        public void SaveToJSON(EmployeeModel data)
        {
            var accounts = GetAllFromJson();


            var existing = accounts.FirstOrDefault(e => e.Name == data.Name);
            if (existing != null) accounts.Remove(existing);

            accounts.Add(data);

            using (var outputStream = File.Create(_jsonFileName))
            {
                using (var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions { SkipValidation = true, Indented = true }))
                {
                    JsonSerializer.Serialize<List<EmployeeModel>>(writer, accounts);
                }
            }
        }

        public void SaveToDatabase(EmployeeModel data)
        {

            Console.WriteLine("Database Save Triggered (Simulated)");
        }
    }
}