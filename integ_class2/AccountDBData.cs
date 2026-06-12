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
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string query = "IF EXISTS (SELECT 1 FROM employees WHERE name = @n) " +
                               "UPDATE employees SET status = @s, details = @d, salary = @sal, department = @dept WHERE name = @n " +
                               "ELSE INSERT INTO employees (name, status, details, salary, department) VALUES (@n, @s, @d, @sal, @dept)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", data.Name);
                cmd.Parameters.AddWithValue("@s", data.Status);
                cmd.Parameters.AddWithValue("@d", data.Details);
                cmd.Parameters.AddWithValue("@sal", data.Salary);
                cmd.Parameters.AddWithValue("@dept", data.Department);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<EmployeeModel> GetAll()
        {
            var list = new List<EmployeeModel>();
            using (var conn = new SqlConnection(_connStr))
            {
                string query = "SELECT name, status, details, salary, department FROM employees";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeModel
                        {
                            Name = reader["name"].ToString() ?? string.Empty,
                            Status = reader["status"].ToString() ?? string.Empty,
                            Details = reader["details"].ToString() ?? string.Empty,
                            Salary = reader["salary"] != DBNull.Value ? Convert.ToDecimal(reader["salary"]) : 0,
                            Department = reader["department"].ToString() ?? string.Empty
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(string name)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string query = "DELETE FROM employees WHERE name = @n";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}