using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ProjectWebApp.classes
{
   public class Employee
    {
        SqlConnection conn = Connections.GetConeection();
        public int EmployeeNum { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Employee() { }
        
        public Employee(int employeeNum, string name, string password)
        {
            EmployeeNum = employeeNum;
            Name = name;
            Password = password;
        }

        public void getEmployee(int empNum)
        {
            string sqlSelect = $"SELECT * FROM tblEmployee WHERE EmployeeNum = {empNum}";

            using (conn)
            {
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, conn);
                conn.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeNum = Convert.ToInt32(reader[0]);
                        Name = (string)reader[1];
                        Password = (string)reader[2];
                    }
                }
            }
        }
    }
}
