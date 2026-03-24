using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; 
using integ_class1;

namespace integ_class2
{
    public class AccountDBData : IEmployeeData
    {
       
        private string _connStr = "server=localhost;database=emp_db;user=root;password=yourpassword";

        public void Save(EmployeeModel data)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                string query = "INSERT INTO employees (name, status, details) VALUES (@n, @s, @d) " +
                               "ON DUPLICATE KEY UPDATE status=@s, details=@d";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", data.Name);
                cmd.Parameters.AddWithValue("@s", data.Status);
                cmd.Parameters.AddWithValue("@d", data.Details);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<EmployeeModel> GetAll()
        {
            var list = new List<EmployeeModel>();

            using (var conn = new MySqlConnection(_connStr))
            {
                string query = "SELECT name, status, details FROM employees";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeModel
                        {
                            Name = reader.GetString("name"),
                            Status = reader.GetString("status"),
                            Details = reader.GetString("details")
                        });
                    }
                }
            }
            return list;
        }
    }
}