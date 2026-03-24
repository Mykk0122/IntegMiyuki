using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using integ_class1;

namespace integ_class2
{
    public class AccountJsonData : IEmployeeData
    {
        private string _path = "data.json";

        public List<EmployeeModel> GetAll()
        {
            if (!File.Exists(_path) || new FileInfo(_path).Length == 0) 
                return new List<EmployeeModel>();

            using (var stream = File.OpenRead(_path))
            {
                return JsonSerializer.Deserialize<List<EmployeeModel>>(stream) ?? new List<EmployeeModel>();
            }
        }

        public void Save(EmployeeModel data)
        {
            var accounts = GetAll();
            var existing = accounts.FirstOrDefault(e => e.Name == data.Name);
            if (existing != null) accounts.Remove(existing);
            accounts.Add(data);

            using (var outputStream = File.Create(_path))
            {
                using (var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions { Indented = true }))
                {
                    JsonSerializer.Serialize<List<EmployeeModel>>(writer, accounts);
                }
            }
        }
    }
}