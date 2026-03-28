using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using integ_class1;

namespace integ_class2
{
    public class AccountDBData : IEmployeeData
    {

        private string _connStr = @"Server=(localdb)\MSSQLLocalDB;Database=emp_db;Trusted_Connection=True;Encrypt=False;";

        public void Save(EmployeeModel data)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                string query = "IF EXISTS (SELECT 1 FROM employees WHERE name = @n) " +
                               "UPDATE employees SET status = @s, details = @d WHERE name = @n " +
                               "ELSE INSERT INTO employees (name, status, details) VALUES (@n, @s, @d)";

                SqlCommand cmd = new SqlCommand(query, conn);
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
            using (var conn = new SqlConnection(_connStr))
            {
                string query = "SELECT name, status, details FROM employees";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeModel
                        {
                            Name = reader["name"].ToString(),
                            Status = reader["status"].ToString(),
                            Details = reader["details"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}